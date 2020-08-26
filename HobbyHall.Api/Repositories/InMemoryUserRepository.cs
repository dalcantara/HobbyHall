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

        public async Task<User> GetByUsernameAsync(string userId)
        {
            johnDoe.Id = userId;
            return await Task.FromResult(johnDoe);
        }

        public Task<User> UpdateAsync(string Username, User User)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> CreateAsync(User User)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string Username)
        {
            throw new System.NotImplementedException();
        }
    }
}
