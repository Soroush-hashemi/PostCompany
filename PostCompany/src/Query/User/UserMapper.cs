using Query.User.DTO;

namespace Query.User;
public static class UserMapper
{
    public static UserDto Map(this Domain.User.User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            CreationDate = user.CreationDate,
            PhoneNumber = user.PhoneNumber,
            UserName = user.UserName,
            Roles = (DTO.UserRoleDto)user.Roles,
            Password = user.Password,
        };
    }

    public static List<UserDto> MapList(this List<Domain.User.User> users)
    {
        return users.Select(user => user.Map()).ToList();
    }
}