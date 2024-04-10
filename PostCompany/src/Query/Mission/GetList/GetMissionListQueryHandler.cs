using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Mission.DTO;

namespace Query.Mission.GetList;
public class GetMissionListQueryHandler : IQueryHandler<GetMissionListQuery, List<MissionDto>>
{
    private readonly PostCompanyContext _context;
    public GetMissionListQueryHandler(PostCompanyContext context)
    {
        _context = context;
    }

    public async Task<List<MissionDto>> Handle(GetMissionListQuery request, CancellationToken cancellationToken)
    {
        var missions = await _context.Missions.ToListAsync(cancellationToken);

        return missions.MapList();
    }
}