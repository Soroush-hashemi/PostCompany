using Common.Domain.Bases;
using Common.Domain.ValueObjects;

namespace Domain.User;
public class User : BaseEntity
{
    public string UserName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public UserRole Roles { get; private set; }

    private User()
    {

    }

    public User(string userName, PhoneNumber phoneNumber,
        string password)
    {
        UserName = userName;
        PhoneNumber = phoneNumber;
        Password = password;
        Roles = UserRole.admin; 
 // هر کاربری که ساخته بشه ادمینه اینو میشد کاری کرد که هر کاربر که تازه ساخته میشه یوزر باشه
 // و فقط یکنفر ادمین بشه اما برای راحتی اجرای پروژه این کار رو کردم
    }
}