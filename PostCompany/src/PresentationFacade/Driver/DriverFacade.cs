using Application.Driver.Add;
using Application.Driver.GiveMission;
using Application.Driver.UpdateLocation;
using Common.Application;
using Common.Domain.ValueObjects;
using MediatR;
using Query.Driver.DTO;
using Query.Driver.GetCurrentLocation;
using Query.Driver.GetList;

namespace PresentationFacade.Driver;
public class DriverFacade : IDriverFacade
{
    private readonly IMediator _mediator;
    public DriverFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Add(AddDriverCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> GiveMission(long DriverId, long MissionId)
    {
        return await _mediator.Send(new GiveMissionToDriverCommand(DriverId, MissionId));
    }

    public async Task<GeoLocation> GetDriverCurrentLocation(long DriverId)
    {
        return await _mediator.Send(new GetDriverCurrentLocationQuery(DriverId));
    }

    public async Task<List<DriverDto>> GetDriverList()
    {
        return await _mediator.Send(new GetDriverListQuery());
    }
}