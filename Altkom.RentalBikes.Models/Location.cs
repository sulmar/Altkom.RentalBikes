using Altkom.RentalBikes.Models.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models
{
    [TypeConverter(typeof(LocationConverter))]
    public partial class Location : Base
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public User User { get; set; }

        public IList<string> Items { get; set; }
    }
}
