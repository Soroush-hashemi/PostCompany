using Common.Application.Validation;
using FluentValidation;

namespace Application.Driver.Add;
public class AddDriverCommandValidator : AbstractValidator<AddDriverCommand>
{
    public AddDriverCommandValidator()
    {
        RuleFor(v => v.PhoneNumber).NotNull().NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"));

        RuleFor(v => v.FullName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام و نام‌خانوادگی"));
    }
}