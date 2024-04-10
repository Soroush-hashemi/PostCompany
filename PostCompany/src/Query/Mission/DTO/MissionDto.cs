using Common.Domain.ValueObjects;
using Common.Query.Bases;
using Domain.Mission;

namespace Query.Mission.DTO;
public class MissionDto : BaseDto
{
    public GeoLocation CurrentLocation { get; set; }
    public string Beginning { get; set; }
    public string Destination { get; set; }
    public long? DriverId { get; set; }
    public StatusDto status { get; set; }
}


public enum StatusDto
{
    Processing,
    Done,
}