using FluentValidation;
using EasyAuthentication.Constants;

namespace EasyAuthentication.Models.Request.Validators
{
    public class SetPassValidators : AbstractValidator<SetPass>
    {
        public SetPassValidators()
        {
            RuleFor(x => x.Pass)
                .NotEmpty().WithMessage(IdentityMessages.RequiredPassword)
                .NotNull().WithMessage(IdentityMessages.RequiredPassword);

            RuleFor(x => x.RePass)
                .NotEmpty().WithMessage(IdentityMessages.RequiredRePassword)
                .NotNull().WithMessage(IdentityMessages.RequiredRePassword);

            RuleFor(x => x.RePass)
                .Equal(x => x.Pass)
                .WithMessage(IdentityMessages.PasswordNotMatch); 

            RuleFor(u => u.UserType).GreaterThan(0).LessThan(3).WithMessage(IdentityMessages.UserTypeError);
        }
    }
}
