using Query.Driver.DTO;

namespace Query.Driver;
public static class DriverMapper
{
    public static DriverDto Map(this Domain.Driver.Driver driver)
    {
        return new DriverDto()
        {
            Id = driver.Id,
            CreationDate = driver.CreationDate,
            CurrentLocation = driver.CurrentLocation,
            PhoneNumber = driver.PhoneNumber,
            FullName = driver.FullName,
            MissionId = driver.MissionId,
            IsFree = driver.IsFree,
        };
    }

    public static List<DriverDto> MapList(this List<Domain.Driver.Driver> drivers)
    {
        return drivers.Select(driver => driver.Map()).ToList();
    }
}