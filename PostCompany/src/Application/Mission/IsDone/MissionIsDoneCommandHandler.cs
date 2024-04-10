using Common.Application;
using Domain.Driver.Repository;
using Domain.Mission;
using Domain.Mission.Repository;

namespace Application.Mission.IsDone;
public class MissionIsDoneCommandHandler : IBaseCommandHandler<MissionIsDoneCommand>
{
    private readonly IMissionRepository _missionRepository;
    private readonly IDriverRepository _driverRepository;
    public MissionIsDoneCommandHandler(IMissionRepository missionRepository, IDriverRepository driverRepository)
    {
        _missionRepository = missionRepository;
        _driverRepository = driverRepository;
    }

    public async Task<OperationResult> Handle(MissionIsDoneCommand request, CancellationToken cancellationToken)
    {
        var mission = await _missionRepository.GetTracking(request.MissionId);
        if (mission == null)
            return OperationResult.NotFound("ماموریتی با این مشخصات یافت نشد");

        await DriverMissionIsDone(mission.DriverId);
        mission.IsDone();

        await _missionRepository.Save();
        return OperationResult.Success();
    }

    private async Task<OperationResult> DriverMissionIsDone(long? driver)
    {
        var Driver = await _driverRepository.GetTracking(driver);
        Driver.MissionDone();

        await _driverRepository.Save();
        return OperationResult.Success();
    }
}