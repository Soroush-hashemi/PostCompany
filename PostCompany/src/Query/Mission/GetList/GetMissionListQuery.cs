using Common.Query;
using Query.Mission.DTO;

namespace Query.Mission.GetList;
public record GetMissionListQuery : IQuery<List<MissionDto>>; 