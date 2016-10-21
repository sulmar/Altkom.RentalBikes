using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Interfaces
{
    public interface IBikesService
    {
        IList<Bike> GetBikes();

        Bike GetBike(int bikeId);

        Bike GetBike(string number);

        IList<Bike> GetBikes(User station);

        void AddBike(Bike bike);

        void UpdateBike(Bike bike);

        void RemoveBike(int bikeId);

    }
}
