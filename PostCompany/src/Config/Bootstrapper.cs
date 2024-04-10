using Application.Driver;
using Application.Mission.Create;
using Domain.Driver.Service;
using FluentValidation;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.Adapter;
using MQTTnet.Client;
using MQTTnet.Diagnostics;
using MQTTnet.Implementations;
using PresentationFacade;
using Query.Driver.GetCurrentLocation;

namespace Config;
public static class Bootstrapper
{
    public static void ConfigBootstrapper(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);
        services.AddMediatR(typeof(CreateMissionCommand).Assembly);
        services.AddMediatR(typeof(CreateMissionCommandHandler).Assembly);
        services.AddMediatR(typeof(GetDriverCurrentLocationQuery).Assembly);
        services.AddMediatR(typeof(GetDriverCurrentLocationQueryHandler).Assembly);

        //services.AddTransient<IMqttClient, MqttClient>();
        //services.AddTransient<IMqttClientAdapterFactory, MqttClientAdapterFactory>();
        //services.AddTransient<IMqttNetLogger, MqttNetLogger>();

        FacadeBootstrapper.InitFacadeDependency(services);
        services.AddTransient<IDriverDomainService, DriverDomainService>();

        services.AddValidatorsFromAssembly(typeof(CreateMissionCommandValidator).Assembly);
    }
}