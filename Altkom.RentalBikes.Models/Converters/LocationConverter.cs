using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Models.Converters
{
    public class LocationConverter : TypeConverter
    {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var input = value as string;

            var values = input.Split(',');

            double lat = 0;
            double lng = 0;

            if (Double.TryParse(values[0], NumberStyles.Any, CultureInfo.InvariantCulture, out lat)
                && Double.TryParse(values[1], NumberStyles.Any, CultureInfo.InvariantCulture, out lng))
            {
                var location = new Location { Latitude = lat, Longitude = lng };

                return location;
            }

            
            return base.ConvertFrom(context, culture, value);
        }
    }
}
