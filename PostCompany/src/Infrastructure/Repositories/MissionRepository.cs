using Infrastructure.Repositories.Base;
using Domain.Mission.Repository;
using Domain.Mission;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;
public class MissionRepository : BaseRepository<Mission>, IMissionRepository
{
    public MissionRepository(PostCompanyContext context) : base(context)
    {
        
    }
}