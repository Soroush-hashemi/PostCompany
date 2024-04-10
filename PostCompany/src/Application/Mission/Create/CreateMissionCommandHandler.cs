using Common.Application;
using Common.Domain.Exceptions;
using Domain.Driver.Repository;
using Domain.Mission.Repository;

namespace Application.Mission.Create;
public class CreateMissionCommandHandler : IBaseCommandHandler<CreateMissionCommand>
{
    private readonly IMissionRepository _missionRepository;
    private readonly IDriverRepository _driverRepository;
    public CreateMissionCommandHandler(IMissionRepository missionRepository, IDriverRepository driverRepository)
    {
        _missionRepository = missionRepository;
        _driverRepository = driverRepository;
    }

    public async Task<OperationResult> Handle(CreateMissionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.DriverId != null && request.DriverId != 0)
            {
                var mission = new Domain.Mission.Mission(request.CurrentLocation,
                    request.Beginning, request.Destination, request.DriverId);

                _missionRepository.Add(mission);
            }

            long driverId = _driverRepository.WhichDriverIsCloser(request.CurrentLocation);

            var Mission = new Domain.Mission.Mission(request.CurrentLocation,
                request.Beginning, request.Destination, driverId);

            _missionRepository.Add(Mission);
            await _missionRepository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}