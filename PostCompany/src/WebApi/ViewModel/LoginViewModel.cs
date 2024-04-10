using Common.Application.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel;
public class LoginViewModel
{
    public LoginViewModel(string phoneNumber , string password)
    {
        PhoneNumber = phoneNumber;
        Password = password;
    }

    [Required(ErrorMessage = "شماره تلفن را وارد کنید")]
    [BindProperty]
    [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
    [BindProperty]
    public string Password { get; set; }
}