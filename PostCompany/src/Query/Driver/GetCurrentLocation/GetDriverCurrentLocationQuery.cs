using Common.Domain.ValueObjects;
using Common.Query;

namespace Query.Driver.GetCurrentLocation;
public record GetDriverCurrentLocationQuery(long DriverId) : IQuery<GeoLocation>;