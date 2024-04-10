using Common.Application.Validation;
using FluentValidation;

namespace Application.Mission.Create;
public class CreateMissionCommandValidator : AbstractValidator<CreateMissionCommand>
{
    public CreateMissionCommandValidator()
    {
        RuleFor(v => v.CurrentLocation).NotNull().NotEmpty().WithMessage(ValidationMessages.required("موقعیت فعلی"));

        RuleFor(v => v.Beginning).NotNull().NotEmpty().WithMessage(ValidationMessages.required("مبدا"));

        RuleFor(v => v.Destination).NotNull().NotEmpty().WithMessage(ValidationMessages.required("مقصد"));
    }
}