using FluentValidation;
using EasyAuthentication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Models.Request.Validators
{
    public class RegisterDtoValidators : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidators()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage(IdentityMessages.RequiredFirstName)
                .NotNull().WithMessage(IdentityMessages.RequiredFirstName)
                .MaximumLength(150).WithMessage($"MaximumLength is 150");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage(IdentityMessages.RequiredLastName)
                .NotNull().WithMessage(IdentityMessages.RequiredLastName)
                .MaximumLength(150).WithMessage($"MaximumLength is 150");

            RuleFor(u => u.MobileNumber)
                .NotEmpty().WithMessage(IdentityMessages.RequiredMobileNumber)
                .NotNull().WithMessage(IdentityMessages.RequiredMobileNumber)
                .MaximumLength(11).WithMessage($"MaximumLength is 11")
                .EmailAddress().WithMessage(IdentityMessages.RequiredMobileNumber);

            RuleFor(u => u.UserType)
                .GreaterThan(0).WithMessage(IdentityMessages.UserTypeError)
                .LessThan(3).WithMessage(IdentityMessages.UserTypeError);
            
        }
    }
}
