using Application.Mission.Create;
using Application.Mission.IsDone;
using Common.Application;
using Domain.Driver;
using MediatR;
using Query.Mission.DTO;
using Query.Mission.GetDriverMission;
using Query.Mission.GetList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PresentationFacade.Mission;
public class MissionFacade : IMissionFacade
{
    private readonly IMediator _mediator;
    public MissionFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateMissionCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> IsDone(long MissionId)
    {
        return await _mediator.Send(new MissionIsDoneCommand(MissionId));
    }

    public async Task<List<MissionDto>> GetDriverMission(long DriverId)
    {
        return await _mediator.Send(new GetDriverMissionQuery(DriverId));
    }

    public async Task<List<MissionDto>> GetMissionList()
    {
        return await _mediator.Send(new GetMissionListQuery());
    }
}