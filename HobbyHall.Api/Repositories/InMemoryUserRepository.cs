using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HobbyHall.Api.Models;

namespace HobbyHall.Api.Repositories
{
    public class InMemoryUserRepository : IReadOnlyUserRepository, IMutableUserRepository
    {
        private User johnDoe = new User { FirstName = "John", LastName = "Doe" };

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = new List<User>();
            users.Add(johnDoe);
            return await Task.FromResult(users.AsEnumerable<User>());
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            johnDoe.Id = userId;
            return await Task.FromResult(johnDoe);
        }

        public Task<User> Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Create(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
