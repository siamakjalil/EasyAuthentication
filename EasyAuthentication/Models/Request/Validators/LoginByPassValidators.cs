using FluentValidation;
using EasyAuthentication.Constants;

namespace EasyAuthentication.Models.Request.Validators
{
    public class LoginByPassValidators : AbstractValidator<LoginByPass>
    {
        public LoginByPassValidators()
        {
            RuleFor(u => u.MobileNumber)
                .NotEmpty().WithMessage(IdentityMessages.RequiredMobileNumber)
                .NotNull().WithMessage(IdentityMessages.RequiredMobileNumber)
                .MaximumLength(11).WithMessage($"MaximumLength is 11")
                .MinimumLength(11).WithMessage($"MaximumLength is 11");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(IdentityMessages.RequiredRePassword)
                .NotNull().WithMessage(IdentityMessages.RequiredRePassword);
        }
    }
}
