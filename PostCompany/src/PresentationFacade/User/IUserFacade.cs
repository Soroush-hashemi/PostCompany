using Application.User.Register;
using Common.Application;
using Query.User.DTO;

namespace PresentationFacade.User;
public interface IUserFacade
{
    Task<OperationResult> Register(RegisterUserCommand command);

    Task<UserDto> GetPhoneNumberById(string phoneNumber);

}