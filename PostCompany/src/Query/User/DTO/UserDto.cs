using Common.Domain.ValueObjects;
using Common.Query.Bases;
using Domain.User;

namespace Query.User.DTO;
public class UserDto : BaseDto
{
    public string UserName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Password { get; set; }
    public UserRoleDto Roles { get; set; }
}

public enum UserRoleDto
{
    admin,
    user
}