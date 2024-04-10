using Common.Application;
using Common.Domain.Exceptions;
using Domain.Driver.Repository;
using Domain.Driver.Service;

namespace Application.Driver.GiveMission;
public class GiveMissionToDriverCommandHandler : IBaseCommandHandler<GiveMissionToDriverCommand>
{
    public readonly IDriverRepository _driverRepository;
    public readonly IDriverDomainService _driverDomainService;
    public GiveMissionToDriverCommandHandler(IDriverRepository driverRepository, IDriverDomainService driverDomainService)
    {
        _driverRepository = driverRepository;
        _driverDomainService = driverDomainService;
    }

    public async Task<OperationResult> Handle(GiveMissionToDriverCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var driver = await _driverRepository.GetTracking(request.DriverId);
            if (driver == null)
                return OperationResult.NotFound();

            if (driver.IsFree == false)
                return OperationResult.Error("راننده در حال انجام ماموریت است");

            driver.GiveMission(request.MissionId, _driverDomainService);

            await _driverRepository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}