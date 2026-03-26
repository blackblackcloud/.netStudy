using DemoApi.Application.Dtos.Region;

namespace DemoApi.Application.Services.Regions;

public interface IRegionApplicationService
{
    Task<IReadOnlyList<RegionResponse>> GetAllAsync();
    Task<RegionResponse?> GetByIdAsync(long id);
    Task<RegionResponse> CreateAsync(CreateRegionRequest request);
    Task<RegionResponse?> UpdateAsync(long id, UpdateRegionRequest request);
    Task<bool> DeleteAsync(long id);
}
