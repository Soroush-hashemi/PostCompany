using Application.Driver.UpdateLocation;
using Common.Domain.ValueObjects;
using Common.Query;
using Infrastructure.Persistence;
using MQTTnet.Client;
using Query.Driver.GetCurrentLocation;

public class GetDriverCurrentLocationQueryHandler : IQueryHandler<GetDriverCurrentLocationQuery, GeoLocation>
{
    // private readonly IMqttClient _mqttClient;

    private readonly PostCompanyContext _context;
    private readonly IUpdateLocationFacade _locationFacade;
    public GetDriverCurrentLocationQueryHandler(/*IMqttClient mqttClient*/ PostCompanyContext context, IUpdateLocationFacade locationFacade)
    {
        //  _mqttClient = mqttClient;
        _context = context;
        _locationFacade = locationFacade;
    }

    public async Task<GeoLocation> Handle(GetDriverCurrentLocationQuery request, CancellationToken cancellationToken)
    {
        // ارسال درخواست به MQTT برای دریافت مختصات مکانی فعلی راننده
        // await _mqttClient.SubscribeAsync($"/test/driver/{request.DriverId}");

        // فرضاً این پیام حاوی مختصات مکانی است
        var longitude = GenerateRandomLongitude();
        var latitude = GenerateRandomLatitude();

        await _locationFacade.UpdateLocation(request.DriverId, longitude, latitude);

        return new GeoLocation(longitude, latitude);
    }

    // تابع برای تولید مختصات مکانی تصادفی
    private double GenerateRandomLongitude()
    {
        Random random = new Random();
        return random.NextDouble() * (180 - (-180)) + (-180);
    }

    private double GenerateRandomLatitude()
    {
        Random random = new Random();
        return random.NextDouble() * (90 - (-90)) + (-90);
    }
}
