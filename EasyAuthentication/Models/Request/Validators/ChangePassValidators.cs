using FluentValidation;
using EasyAuthentication.Constants;

namespace EasyAuthentication.Models.Request.Validators
{
    public class ChangePassValidators : AbstractValidator<ChangePass>
    {
        public ChangePassValidators()
        {
            RuleFor(x => x.NewPass)
                .NotEmpty().WithMessage(IdentityMessages.RequiredPassword)
                .NotNull().WithMessage(IdentityMessages.RequiredPassword);

            RuleFor(x => x.ReNewPass)
                .NotEmpty().WithMessage(IdentityMessages.RequiredRePassword)
                .NotNull().WithMessage(IdentityMessages.RequiredRePassword);

            RuleFor(x => x.ReNewPass)
                .Equal(x => x.NewPass)
                .WithMessage(IdentityMessages.PasswordNotMatch); 
             
        }
    }
}
