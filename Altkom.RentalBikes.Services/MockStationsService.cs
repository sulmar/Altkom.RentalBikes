using Altkom.RentalBikes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.RentalBikes.Models;
using System.Threading;

namespace Altkom.RentalBikes.Services
{
    public class MockStationsService : IStationsService
    {
        private static IList<Station> stations = new List<Station>
        {
            new Station {
                StationId = 1,
                Number = "ST001",
                Address = "Chlodna",
                Capacity = 20,
                Location = new Location { Latitude = 52.1, Longitude = 28.01 },
            },

            new Station {
                StationId = 2,
                Number = "ST002",
                Address = "PKP Dworzec Centalny",
                Capacity = 26,
                Location = new Location { Latitude = 52.1, Longitude = 27.01 },
            },

            new Station {
                StationId = 1,
                Number = "ST003",
                Address = "PKP Dworzec Zachodni",
                Capacity = 4,
                Location = new Location { Latitude = 52.12, Longitude = 28.41 },
            },
        };

        public void Add(Station item)
        {
            item.Id = stations.Max(s => s.Id) + 1;
            stations.Add(item);
        }

        public Task AddAsync(Station item)
        {
            return Task.Run(() => Add(item));
        }

        public void Delete(int id)
        {
            stations.Remove(Get(id));
        }

        public Task DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id));
        }

        public Station Find(Location location)
        {
            var station = stations
                .Select(s => new
                {
                    Station = s,
                    Distance = s.Location.Distance(location)
                })
                .OrderBy(s => s.Distance)
                .FirstOrDefault();

            Thread.Sleep(5000);

            return station.Station;
        }

        public Task<Station> FindAsync(Location location)
        {
            return Task.Run<Station>(() => Find(location));
        }

        public IList<Station> Get()
        {
            return stations;
        }

        public Station Get(int id)
        {
            return stations
                .SingleOrDefault(s => s.StationId == id);
        }

        public Task<IList<Station>> GetAsync()
        {
            return Task.Run(() => Get());
        }

        public Task<Station> GetAsync(int id)
        {
            return Task.Run(() => Get(id));
        }

        public void Update(Station item)
        {
            var station = Get(item.StationId);

            station = item;
        }

        public Task UpdateAsync(Station item)
        {
            return Task.Run(() => Update(item));
        }
    }
}
