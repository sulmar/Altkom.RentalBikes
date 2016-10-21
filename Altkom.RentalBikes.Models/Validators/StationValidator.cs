using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models.Validators
{
    public class StationValidator : AbstractValidator<Station>
    {
        public StationValidator()
        {
            RuleFor(p => p.Number)
                .NotEmpty();

            RuleFor(p => p.Capacity)
                .InclusiveBetween(1, 100);

        }
    }
}
