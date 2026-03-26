using DemoApi.Application.Dtos.Region;
using DemoApi.Application.Services.Regions;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.WebApi.Controllers;

[Route("api/regions")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionApplicationService _regionService;

    public RegionController(IRegionApplicationService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegionResponse>>> GetAll()
    {
        var regions = await _regionService.GetAllAsync();
        return Ok(regions);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<RegionResponse>> GetById(long id)
    {
        var region = await _regionService.GetByIdAsync(id);
        if (region is null)
        {
            return NotFound();
        }

        return Ok(region);
    }

    [HttpPost]
    public async Task<ActionResult<RegionResponse>> Create(CreateRegionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ChineseName))
        {
            ModelState.AddModelError(nameof(request.ChineseName), "ChineseName is required.");
            return ValidationProblem(ModelState);
        }

        try
        {
            var response = await _regionService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(nameof(request.Latitude), ex.Message);
            return ValidationProblem(ModelState);
        }
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<RegionResponse>> Update(long id, UpdateRegionRequest request)
    {
        var region = await _regionService.UpdateAsync(id, request);
        if (region is null)
        {
            return NotFound();
        }

        return Ok(region);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _regionService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
