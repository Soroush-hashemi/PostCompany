using Common.Application;
using MediatR;

namespace Application.Driver.UpdateLocation;
public interface IUpdateLocationFacade
{
    Task<OperationResult> UpdateLocation(long DriverId, double longitude, double latitude);
}

public class UpdateLocationFacade : IUpdateLocationFacade
{
    private readonly IMediator _mediator;
    public UpdateLocationFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> UpdateLocation(long DriverId, double longitude, double latitude)
    {
        return await _mediator.Send(new UpdateLocationCommand(DriverId, longitude, latitude));
    }
}