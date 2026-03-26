namespace DemoApi.domin.valueObjects.RegionVO;
public record Geo
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public Geo(double latitude, double longitude)
    {
        if (longitude < -180 || longitude > 180)
        {
            throw new ArgumentException("longitude invalid");
        }
        if (latitude < -90 || latitude > 90)
        {
            throw new ArgumentException("longitude invalid");
        }
        Latitude = latitude;
        Longitude = longitude;
    }
}

