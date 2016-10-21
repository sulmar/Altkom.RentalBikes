using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Interfaces
{
    public interface IBaseService<TItem, TKey>
        
    {
        IList<TItem> Get();

        TItem Get(TKey id);

        void Add(TItem item);

        void Update(TItem item);

        void Delete(TKey id);

    }
}
