using Application.Mission.Create;
using Common.Application;
using Query.Mission.DTO;

namespace PresentationFacade.Mission;
public interface IMissionFacade
{
    Task<OperationResult> Create(CreateMissionCommand command);
    Task<OperationResult> IsDone(long MissionId);

    Task<List<MissionDto>> GetDriverMission(long DriverId); // راننده ها با این تابع میتونن تمام ماموریت های خودشون رو ببین 
    Task<List<MissionDto>> GetMissionList();
}