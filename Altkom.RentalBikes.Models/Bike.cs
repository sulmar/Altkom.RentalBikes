using Altkom.RentalBikes.Models.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models
{
    [Validator(typeof(BikeValidator))]
    public class Bike : Base
    {
        public int BikeId { get; set; }

        //[Required]
        //[MaxLength(5)]
        public string Number { get; set; }

        public BikeType BikeType { get; set; }

        public bool IsActive { get; set; }

        public User Station { get; set; }

        public string Color { get; set; }

        public override string ToString() => Number;


    }
}
