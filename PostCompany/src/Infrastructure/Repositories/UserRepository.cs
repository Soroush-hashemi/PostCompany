using Infrastructure.Repositories.Base;
using Domain.User;
using Domain.User.Repository;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(PostCompanyContext context) : base(context)
    {

    }
}