using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Interfaces
{
    public interface IStationsService : IBaseService<Station, int>
    {
        Station Find(Location location);

        Task<Station> FindAsync(Location location);
    }
}
