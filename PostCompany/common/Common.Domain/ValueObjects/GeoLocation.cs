namespace Common.Domain.ValueObjects;
public class GeoLocation
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public GeoLocation(double longitude, double latitude)
    {
        Longitude = longitude;
        Latitude = latitude;
    }
}