using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Mission.DTO;

namespace Query.Mission.GetDriverMission;
public class GetDriverMissionQueryHandler : IQueryHandler<GetDriverMissionQuery, List<MissionDto>>
{
    private readonly PostCompanyContext _context;
    public GetDriverMissionQueryHandler(PostCompanyContext context)
    {
        _context = context;
    }

    public async Task<List<MissionDto>> Handle(GetDriverMissionQuery request, CancellationToken cancellationToken)
    {
        var Mission = await _context.Missions.Where(m => m.DriverId == request.DriverId).ToListAsync(cancellationToken);

        return Mission.MapList();
    }
}