using DemoApi.domin.enums.RegionEn;

namespace DemoApi.Application.Dtos.Region;

public record RegionResponse(
    long Id,
    string ChineseName,
    string? EnglishName,
    double AreaValue,
    AreaType AreaUnit,
    RegionLevel Level,
    long? Population,
    double Latitude,
    double Longitude);
