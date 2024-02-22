using FluentValidation;
using EasyAuthentication.Constants;

namespace EasyAuthentication.Models.Request.Validators
{
    public class LoginByPassValidators : AbstractValidator<LoginByPass>
    {
        public LoginByPassValidators()
        {
            RuleFor(m => new { m.MobileNumber, m.Email }).Must(x => ValidData(x.MobileNumber, x.Email))
                .WithMessage("Email or Mobile must be set"); 

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(IdentityMessages.RequiredRePassword)
                .NotNull().WithMessage(IdentityMessages.RequiredRePassword);
        }

        private static bool ValidData(string? mobileNumber, string? email)
        {
            return !string.IsNullOrEmpty(mobileNumber) || !string.IsNullOrEmpty(email);
        }
    }
}
