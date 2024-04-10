using Common.Application;
using Domain.Driver.Repository;

namespace Application.Driver.UpdateLocation;
public class UpdateLocationCommandHandler : IBaseCommandHandler<UpdateLocationCommand>
{
    private readonly IDriverRepository _driverRepository;
    public UpdateLocationCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<OperationResult> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverRepository.GetTracking(request.DriverId);

        driver.SetLocation(request.longitude , request.latitude);

        await _driverRepository.Save();
        return OperationResult.Success();
    }
}