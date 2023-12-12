using FluentValidation;
using EasyAuthentication.Constants;

namespace EasyAuthentication.Models.Request.Validators
{
    public class LoginByAuthCodeValidators : AbstractValidator<LoginByAuthCode>
    {
        public LoginByAuthCodeValidators()
        {
            RuleFor(u => u.MobileNumber)
                .NotEmpty().NotNull().WithMessage(IdentityMessages.RequiredMobileNumber)
                .MaximumLength(11).WithMessage($"MaximumLength is 11")
                .MinimumLength(11).WithMessage($"MaximumLength is 11");

            RuleFor(u => u.ActivationCode)
                .NotEmpty().NotNull().WithMessage(IdentityMessages.RequiredActivationCode)
                .MaximumLength(5).WithMessage($"MaximumLength is 5")
                .MinimumLength(5).WithMessage($"MaximumLength is 5");
        }
    }
}
