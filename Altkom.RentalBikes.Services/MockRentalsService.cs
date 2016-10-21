using Altkom.RentalBikes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.RentalBikes.Models;

namespace Altkom.RentalBikes.Services
{
    public class MockRentalsService : IRentalsService
    {
        private static IList<Rental> rentals = new List<Rental>
        {
            new Rental
            {
                RentalId = 1,
                Bike = new Bike { BikeId = 1 },
                DateFrom = DateTime.Now,
                StationFrom = new Station { Id = 1 },
                DateTo = DateTime.Now.AddMinutes(20),
                StationTo = new Station { Id = 2 },
                Cost = 0.5m,
                User = new User { Id = 1 },
            },
        };

        public void Add(Rental item)
        {
            rentals.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotSupportedException();
        }

        public IList<Rental> Get()
        {
            return rentals;
        }

        public Rental Get(int id)
        {
            return rentals.SingleOrDefault(r => r.Id == id);
        }

        public void Update(Rental item)
        {
            throw new NotSupportedException();
        }
    }
}
