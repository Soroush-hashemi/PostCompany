using Common.Application;

namespace Application.Mission.IsDone;
public record MissionIsDoneCommand(long MissionId) : IBaseCommand;