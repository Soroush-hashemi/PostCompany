using Common.Domain.Bases;
using Common.Domain.ValueObjects;
using Domain.Driver.Service;

namespace Domain.Driver;
public class Driver : BaseEntity
{
    public GeoLocation? CurrentLocation { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string FullName { get; set; }
    public long MissionId { get; set; }
    public bool IsFree { get; set; }

    private Driver()
    {

    }

    public Driver(PhoneNumber phoneNumber, string fullName)
    {
        PhoneNumber = phoneNumber;
        FullName = fullName;
        IsFree = true;
    }

    public void GiveMission(long missionId, IDriverDomainService _domainService)
    {
        Guard(missionId, _domainService);
        MissionId = missionId;
        IsFree = false; // یعنی در حال انجام ماموریته و نمیشه بهش ماموریت داد
    }

    public void MissionDone()
    {
        IsFree = true;
    }

    public void SetLocation(double Longitude, double Latitude)
    {
        CurrentLocation = new GeoLocation(Longitude, Latitude);
    }

    public void Guard(long missionId, IDriverDomainService _domainService)
    {
        _domainService.IsMissionExist(missionId);
    }
}