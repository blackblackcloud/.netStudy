using DemoApi.domin.enums.RegionEn;

namespace DemoApi.Application.Dtos.Region;

public record UpdateRegionRequest(
    RegionLevel Level,
    long? Population);
