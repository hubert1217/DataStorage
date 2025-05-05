using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Models;

namespace Web.Application.Validation
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator() 
        {
            RuleFor(u => u.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(u => u.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(u => u.Description)
                .MaximumLength(100);

            RuleFor(u => u.Email)
                .EmailAddress();

        }
    }
}
