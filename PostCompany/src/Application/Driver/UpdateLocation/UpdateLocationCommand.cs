using Common.Application;

namespace Application.Driver.UpdateLocation;
public record UpdateLocationCommand(long DriverId,double longitude, double latitude) : IBaseCommand;