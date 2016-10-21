using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models.Validators
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.Bike)
                .NotNull();

            RuleFor(p => p.StationFrom)
                .NotNull();

            RuleFor(p => p.User)
                .NotNull();

            RuleFor(p => p.DateFrom)                
                .LessThan(p => p.DateTo)
                .When(p=>p.DateTo.HasValue);

        }
    }
}
