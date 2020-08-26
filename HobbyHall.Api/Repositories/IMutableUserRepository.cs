using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HobbyHall.Api.Models;

namespace HobbyHall.Api.Repositories
{
    public interface IMutableUserRepository
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        void Delete(int id);
    }
}
