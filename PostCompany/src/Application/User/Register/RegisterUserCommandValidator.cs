using Common.Application.Validation;
using FluentValidation;

namespace Application.User.Register;
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(v => v.UserName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));

        RuleFor(v => v.PhoneNumber).NotNull().NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"));

        RuleFor(f => f.Password).NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .MinimumLength(4).WithMessage(ValidationMessages.minLength("کلمه عبور", 4));
    }
}