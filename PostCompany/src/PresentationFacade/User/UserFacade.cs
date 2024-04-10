using Application.User.Register;
using Common.Application;
using MediatR;
using Query.User.DTO;
using Query.Users.GetByPhoneNumber;

namespace PresentationFacade.User;
public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<UserDto> GetPhoneNumberById(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<OperationResult> Register(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}