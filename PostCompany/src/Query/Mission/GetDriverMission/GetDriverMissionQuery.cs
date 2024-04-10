using Common.Query;
using Query.Mission.DTO;

namespace Query.Mission.GetDriverMission;
public record GetDriverMissionQuery(long DriverId) : IQuery<List<MissionDto>>;