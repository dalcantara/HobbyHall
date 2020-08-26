using System.Collections.Generic;
using System.Threading.Tasks;
using HobbyHall.Api.Models;

namespace HobbyHall.Api.Repositories
{
    public interface IReadOnlyUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int userId);
    }
}