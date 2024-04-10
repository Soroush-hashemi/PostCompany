using Application.User.Register;
using Common.Application.SecurityUtil;
using Common.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.User;
using Query.User.DTO;
using System.Security.Claims;
using WebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserFacade _userFacade;

    public UserController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var command = new RegisterUserCommand(model.UserName, model.PhoneNumber, model.Password);
        var result = await _userFacade.Register(command);
        return Ok(result.Message);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var user = await _userFacade.GetPhoneNumberById(model.PhoneNumber);
        if (user == null)
            ModelState.AddModelError("PhoneNumber", "کاربری با مشخصات وارد شده یافت نشد");
        var result = loginHelper(user, model);


        if (result.Status.Equals(OperationResultStatus.Error))
        {
            ModelState.AddModelError("UserName", result.Result.Message);
            return BadRequest(result.Result.Message);
        }

        return Ok();
    }

    private async Task<OperationResult> loginHelper(UserDto user, LoginViewModel model)
    {
        if (user == null)
        {
            var result = OperationResult.Error("کاربری با مشخصات وارد شده یافت نشد");
            return result;
        }

        var password = Sha256Hasher.Hash(model.Password);
        if (password != user.Password)
        {
            var result = OperationResult.Error("کاربری با مشخصات وارد شده یافت نشد");
            return result;
        }

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName.ToString()),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber.Value.ToString()),
            new Claim(ClaimTypes.Role, user.Roles.ToString()),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimPrincipal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties()
        {
            IsPersistent = true
        };

        HttpContext.SignInAsync(claimPrincipal, properties);

        return OperationResult.Success();
    }
}