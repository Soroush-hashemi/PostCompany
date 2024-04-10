using Application.Driver.Add;
using Common.Application;
using Common.Domain.ValueObjects;
using Query.Driver.DTO;

namespace PresentationFacade.Driver;
public interface IDriverFacade
{
    Task<OperationResult> Add(AddDriverCommand command);
    Task<OperationResult> GiveMission(long DriverId, long MissionId);

    Task<GeoLocation> GetDriverCurrentLocation(long DriverId);
    Task<List<DriverDto>> GetDriverList();
}