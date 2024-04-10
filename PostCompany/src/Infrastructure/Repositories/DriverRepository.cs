using Common.Domain.ValueObjects;
using Domain.Driver;
using Domain.Driver.Repository;
using Domain.Mission;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class DriverRepository : BaseRepository<Driver>, IDriverRepository
{
    public DriverRepository(PostCompanyContext context) : base(context)
    {

    }

    public long WhichDriverIsCloser(GeoLocation missionCurrentLocation)
    {
        List<Driver> drivers = new List<Driver>();

        var driversWithoutMission = _context.Drivers
            .Where(d => !_context.Missions.Any(m => m.DriverId == d.Id))
            .ToList();

        drivers.AddRange(driversWithoutMission);

        var driversWithDoneMission = _context.Drivers
            .Where(d => _context.Missions.Any(m => m.DriverId == d.Id && m.status == Status.Done) && d.IsFree == true)
            .ToList();

        drivers.AddRange(driversWithDoneMission);


        Driver closestDriver = null;
        double shortestDistance = double.MaxValue;

        foreach (var driver in drivers)
        {
            double distance = CalculateDistance(driver.CurrentLocation, missionCurrentLocation);
            if (distance < shortestDistance)
            {
                closestDriver = driver;
                shortestDistance = distance;
            }
        }

        return closestDriver.Id;
    }

    private double CalculateDistance(GeoLocation location1, GeoLocation location2)
    {
        double R = 6371; // رادیان زمین بر حسب کیلومتر 

        double lat1 = ToRadians(location1.Latitude);
        double lon1 = ToRadians(location1.Longitude);
        double lat2 = ToRadians(location2.Latitude);
        double lon2 = ToRadians(location2.Longitude);

        double dlon = lon2 - lon1;
        double dlat = lat2 - lat1;

        double a = Math.Pow(Math.Sin(dlat / 2), 2) + // محاسبه فرمول هرسین
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Pow(Math.Sin(dlon / 2), 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)); // محاسبه فاصله بین دو نقطه روی کره زمین

        double distance = R * c; // فاصله با کیلومتر

        return distance;
    }

    private double ToRadians(double angle) // این تابع زاویه را از واحد درجه به رادیان تبدیل می‌کند
    {
        return Math.PI * angle / 180.0;
    }
}