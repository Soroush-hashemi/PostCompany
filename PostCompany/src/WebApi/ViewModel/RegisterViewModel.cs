using Common.Application.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel;
public class RegisterViewModel
{
    public RegisterViewModel(string phoneNumber , string password , string userName)
    {
        PhoneNumber = phoneNumber;
        Password = password;
        UserName = userName;
    }

    [Required(ErrorMessage = "شماره تلفن را وارد کنید")]
    [BindProperty]
    [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "نام کاربری را وارد کنید")]
    public string UserName { get; set; }
}