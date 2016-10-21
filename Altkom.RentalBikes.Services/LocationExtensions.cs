using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Altkom.RentalBikes.Services
{
    public static class LocationExtensions
    {
        public static double Distance(this Location from, Location to)
        {
            var distance = Sqrt(
                Pow(from.Latitude - to.Latitude, 2)
                + Pow(from.Longitude - to.Longitude, 2));

            return distance;
        }
    }
}
