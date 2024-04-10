using Common.Application;
using Common.Domain.ValueObjects;
using MediatR;

namespace Application.User.Register;
public class RegisterUserCommand : IBaseCommand
{
    public string UserName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Password { get; set; }

    public RegisterUserCommand(string userName, string phoneNumber, string password)
    {
        UserName = userName;
        PhoneNumber = new PhoneNumber(phoneNumber);
        Password = password;
    }
}