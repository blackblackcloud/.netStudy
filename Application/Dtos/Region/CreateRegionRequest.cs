using DemoApi.domin.enums.RegionEn;

namespace DemoApi.Application.Dtos.Region;

public record CreateRegionRequest(
    string ChineseName,
    string? EnglishName,
    double AreaValue,
    AreaType AreaUnit,
    RegionLevel Level,
    long? Population,
    double Latitude,
    double Longitude);
