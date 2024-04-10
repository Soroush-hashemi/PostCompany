using Common.Application;
using Common.Domain.Exceptions;
using Domain.Driver.Repository;

namespace Application.Driver.Add;
public class AddDriverCommandHandler : IBaseCommandHandler<AddDriverCommand>
{
    private readonly IDriverRepository _driverRepository;
    public AddDriverCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<OperationResult> Handle(AddDriverCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var driver = new Domain.Driver.Driver(request.PhoneNumber, request.FullName);

            var longitude = GenerateRandomLongitude();
            var latitude = GenerateRandomLatitude();

            driver.SetLocation(longitude, latitude);

            _driverRepository.Add(driver);
            await _driverRepository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
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