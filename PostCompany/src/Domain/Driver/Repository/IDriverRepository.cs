using Common.Domain.Repository;
using Common.Domain.ValueObjects;

namespace Domain.Driver.Repository;
public interface IDriverRepository : IBaseRepository<Driver>
{
    // نزدیک ترین راننده به ماموریت رو پیدا میکنه و ایدی اونو برمیگردونه
    public long WhichDriverIsCloser(GeoLocation MissionCurrentLocation);
}