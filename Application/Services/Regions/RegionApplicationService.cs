using DemoApi.Application.Dtos.Region;
using DemoApi.domin.entities;
using DemoApi.domin.valueObjects.RegionVO;
using DemoApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Application.Services.Regions;

public class RegionApplicationService : IRegionApplicationService
{
    private readonly SchoolDbContext _dbContext;

    public RegionApplicationService(SchoolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<RegionResponse>> GetAllAsync()
    {
        return await _dbContext.Cities
            .AsNoTracking()
            .Select(r => new RegionResponse(
                r.Id,
                r.Name.Chinese,
                r.Name.English,
                r.Area.Value,
                r.Area.Unit,
                r.Level,
                r.Population,
                r.Location.Latitude,
                r.Location.Longitude))
            .ToListAsync();
    }

    public async Task<RegionResponse?> GetByIdAsync(long id)
    {
        var region = await _dbContext.Cities
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        return region is null ? null : ToResponse(region);
    }

    public async Task<RegionResponse> CreateAsync(CreateRegionRequest request)
    {
        var region = new Region(
            new MultilingualString(request.ChineseName.Trim(), request.EnglishName?.Trim()),
            new Area(request.AreaValue, request.AreaUnit),
            new Geo(request.Latitude, request.Longitude),
            request.Level);

        if (request.Population.HasValue)
        {
            region.ChangePopulation(request.Population.Value);
        }

        _dbContext.Cities.Add(region);
        await _dbContext.SaveChangesAsync();

        return ToResponse(region);
    }

    public async Task<RegionResponse?> UpdateAsync(long id, UpdateRegionRequest request)
    {
        var region = await _dbContext.Cities.FirstOrDefaultAsync(r => r.Id == id);
        if (region is null)
        {
            return null;
        }

        region.ChangeLevel(request.Level);
        if (request.Population.HasValue)
        {
            region.ChangePopulation(request.Population.Value);
        }

        await _dbContext.SaveChangesAsync();

        return ToResponse(region);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var region = await _dbContext.Cities.FirstOrDefaultAsync(r => r.Id == id);
        if (region is null)
        {
            return false;
        }

        _dbContext.Cities.Remove(region);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    private static RegionResponse ToResponse(Region region)
    {
        return new RegionResponse(
            region.Id,
            region.Name.Chinese,
            region.Name.English,
            region.Area.Value,
            region.Area.Unit,
            region.Level,
            region.Population,
            region.Location.Latitude,
            region.Location.Longitude);
    }
}
