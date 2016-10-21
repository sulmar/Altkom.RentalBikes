using Altkom.RentalBikes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.RentalBikes.Models;

namespace Altkom.RentalBikes.Services
{
    public class MockBikesService : IBikesService, IDisposable
    {
        private static IList<Bike> bikes = new List<Bike>
        {
            new Bike
            {
                BikeId = 1,
                Number = "R001",
                BikeType = BikeType.City,
                IsActive = true,
            },

            new Bike
            {
                BikeId = 2,
                Number = "R002",
                BikeType = BikeType.Kids,
                IsActive = true,
            },

            new Bike
            {
                BikeId = 3,
                Number = "R003",
                BikeType = BikeType.Tandem,
                IsActive = true,
            },
        };

        public void AddBike(Bike bike)
        {
            bike.BikeId = bikes.Max(b => b.BikeId) + 1;
            bikes.Add(bike);
        }

        public void Dispose()
        {
            Console.WriteLine("clean up...");
        }

        public Bike Find(Location location)
        {
            throw new NotImplementedException();
        }

        public Bike GetBike(string number)
        {
            return bikes.SingleOrDefault(b => b.Number == number);
        }

        public Bike GetBike(int bikeId)
        {
            return bikes.SingleOrDefault(b => b.BikeId == bikeId);
        }

        public IList<Bike> GetBikes()
        {
            return bikes;
        }

        public IList<Bike> GetBikes(User station)
        {
            return bikes
                .Where(b => b.Station == station)
                .ToList();
        }

        public void RemoveBike(int bikeId)
        {
            var bike = GetBike(bikeId);

            if (bike != null)
                bikes.Remove(bike);
            else
                throw new KeyNotFoundException($"Not found bike {bikeId}");
        }

        public void UpdateBike(Bike bike)
        {
            var foundBike = GetBike(bike.BikeId);

            foundBike = bike;


        }
    }
}
