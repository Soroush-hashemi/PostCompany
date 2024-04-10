using Common.Application;
using Common.Domain.ValueObjects;
using Domain.Mission;

namespace Application.Mission.Create;
public class CreateMissionCommand : IBaseCommand
{
    public GeoLocation CurrentLocation { get; set; }
    public string Beginning { get; set; }
    public string Destination { get; set; }
    public long? DriverId { get; set; }
    public Status status { get; set; }
}