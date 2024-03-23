using FluentValidation;
using EasyAuthentication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Models.Request.Validators
{
    public class UserDtoValidators : AbstractValidator<UserDto>
    {
        public UserDtoValidators()
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
                .NotEmpty().When(m => string.IsNullOrEmpty(m.Email)).WithMessage(IdentityMessages.RequiredMobileNumber)
                .NotNull().When(m => string.IsNullOrEmpty(m.Email)).WithMessage(IdentityMessages.RequiredMobileNumber)
                .MaximumLength(150).WithMessage($"MaximumLength is 150");
            
            RuleFor(u => u.Email)
                .NotEmpty().When(m => string.IsNullOrEmpty(m.MobileNumber)).WithMessage(IdentityMessages.RequiredEmail)
                .NotNull().When(m => string.IsNullOrEmpty(m.MobileNumber)).WithMessage(IdentityMessages.RequiredEmail)
                .EmailAddress().WithMessage(IdentityMessages.EmailNotValid); 

            RuleFor(u => u.UserType)
                .GreaterThan(0).WithMessage(IdentityMessages.UserTypeError)
                .LessThan(3).WithMessage(IdentityMessages.UserTypeError);
            
        }
    }
}
