using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models.Validators
{
    public class BikeValidator : AbstractValidator<Bike>
    {
        public BikeValidator()
        {
            RuleFor(p => p.Number)
                .NotEmpty()
                .Length(1, 5)
                .WithMessage("Bledna wartosc pola");



        }
    }
}
