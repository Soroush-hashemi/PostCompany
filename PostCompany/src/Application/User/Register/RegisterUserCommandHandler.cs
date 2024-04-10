using Common.Application;
using Common.Domain.Exceptions;
using Domain.User.Repository;
using Common.Application.SecurityUtil;

namespace Application.User.Register;
public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new Domain.User.User(request.UserName, request.PhoneNumber, password);

            _userRepository.Add(user);
            await _userRepository.Save();
            return OperationResult.Success();

        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}