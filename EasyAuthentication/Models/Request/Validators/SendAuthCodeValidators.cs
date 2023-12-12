using FluentValidation;
using EasyAuthentication.Constants;

namespace EasyAuthentication.Models.Request.Validators
{
    public class SendAuthCodeValidators : AbstractValidator<SendAuthCode>
    {
        public SendAuthCodeValidators()
        {
            RuleFor(u => u.MobileNumber).NotEmpty().WithMessage(IdentityMessages.RequiredMobileNumber).NotNull().WithMessage(IdentityMessages.RequiredMobileNumber)
                .MaximumLength(11).WithMessage($"MaximumLength is 11")
                .MinimumLength(11).WithMessage($"MaximumLength is 11");
        }
    }
}
