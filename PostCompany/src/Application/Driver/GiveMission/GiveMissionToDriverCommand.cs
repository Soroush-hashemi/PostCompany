using Common.Application;

namespace Application.Driver.GiveMission;
public record GiveMissionToDriverCommand(long DriverId,long MissionId) : IBaseCommand;