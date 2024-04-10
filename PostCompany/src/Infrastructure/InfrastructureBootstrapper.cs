using Domain.Driver.Repository;
using Domain.Mission.Repository;
using Domain.User.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IMissionRepository, MissionRepository>();
        services.AddTransient<IDriverRepository, DriverRepository>();

        services.AddDbContext<PostCompanyContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}