using Common.Domain.Bases;
using Common.Domain.ValueObjects;

namespace Domain.Mission;
public class Mission : BaseEntity
{
    public GeoLocation CurrentLocation { get; set; }
    public string Beginning { get; set; } // مبدا 
    public string Destination { get; set; } // مقصد
    public long? DriverId { get; set; }
    public Status status { get; set; }

    private Mission()
    {

    }

    public Mission(GeoLocation currentLocation, string beginning, 
        string destination, long? driverId)
    {
        CurrentLocation = currentLocation;
        Beginning = beginning;
        Destination = destination;
        DriverId = driverId;
        status = Status.Processing;
    }

    public void IsDone()
    {
        status = Status.Done;
    }
}

public enum Status
{
    Processing,
    Done,
}