using Application.Driver.UpdateLocation;
using Microsoft.Extensions.DependencyInjection;
using PresentationFacade.Driver;
using PresentationFacade.Mission;
using PresentationFacade.User;

namespace PresentationFacade;
public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddTransient<IDriverFacade, DriverFacade>();
        services.AddTransient<IMissionFacade, MissionFacade>();
        services.AddTransient<IUserFacade, UserFacade>();
        services.AddTransient<IUpdateLocationFacade, UpdateLocationFacade>();
    }
}