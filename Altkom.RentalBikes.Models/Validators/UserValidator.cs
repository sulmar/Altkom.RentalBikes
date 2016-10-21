using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty();

            RuleFor(p => p.LastName)
                .NotEmpty();

            RuleFor(p => p.PhoneNumber)
                .NotEmpty();

            RuleFor(p => p.Email)
                .NotEmpty();

        }
    }
}
