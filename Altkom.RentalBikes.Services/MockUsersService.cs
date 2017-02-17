using Altkom.RentalBikes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.RentalBikes.Models;

namespace Altkom.RentalBikes.Services
{
    public class MockUsersService : IUsersService
    {
        private static IList<User> users = new List<User>
        {
            new User {
                Id = 1,
                FirstName = "Marcin",
                LastName = "Sulecki",
                Email = "marcin.sulecki@altkom.pl",
            },
        };

        public void Add(User item)
        {
            users.Add(item);
        }

        public Task AddAsync(User item)
        {
            return Task.Run(() => Add(item));
        }

        public void Delete(int id)
        {
            var user = Get(id);

            users.Remove(user);
        }

        public Task DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id));
        }

        public IList<User> Get()
        {
            return users;
        }

        public User Get(int id)
        {
            return users.SingleOrDefault(u => u.Id == id);
        }

        public Task<IList<User>> GetAsync()
        {
            return Task.Run(() => Get());
        }

        public Task<User> GetAsync(int id)
        {
            return Task.Run(() => Get(id));
        }

        public void Update(User item)
        {
            var foundUser = Get(item.Id);

            foundUser = item;
        }

        public Task UpdateAsync(User item)
        {
            return Task.Run(() => Update(item));
        }
    }
}
