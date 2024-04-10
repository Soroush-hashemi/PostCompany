using Common.Domain.Exceptions;
using Domain.Driver.Service;
using Domain.Mission.Repository;

namespace Application.Driver;
public class DriverDomainService : IDriverDomainService
{
    public readonly IMissionRepository _missionRepository;
    public DriverDomainService(IMissionRepository missionRepository)
    {
        _missionRepository = missionRepository;
    }

    public void IsMissionExist(long missionId)
    {
        var Exists = _missionRepository.Exists(m => m.Id == missionId); //  اگر در سیستم وجود نداشت 0 رو برگشت میده
        if (Exists == false)
            throw new NullOrEmptyException("ماموریت وجود ندارد");
    }
}