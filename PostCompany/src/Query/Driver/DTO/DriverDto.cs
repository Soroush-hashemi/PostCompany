using Common.Domain.ValueObjects;
using Common.Query.Bases;

namespace Query.Driver.DTO;
public class DriverDto : BaseDto
{
    public GeoLocation CurrentLocation { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string FullName { get; set; }
    public long MissionId { get; set; }
    public bool IsFree { get; set; }
}