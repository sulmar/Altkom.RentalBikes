using Altkom.RentalBikes.Models.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models
{
    [Validator(typeof(StationValidator))]
    public class Station : Base
    {
        public int StationId
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string Number { get; set; }

        public Location Location { get; set; }

        public int Capacity { get; set; }

        public string Address { get; set; }

    }
}
