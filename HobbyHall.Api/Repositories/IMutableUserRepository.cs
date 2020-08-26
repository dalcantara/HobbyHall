using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HobbyHall.Api.Models;

namespace HobbyHall.Api.Repositories
{
    public interface IMutableUserRepository
    {
        Task<User> Create(User User);
        Task<User> Update(string UserName, User Usre);
        void Delete(string Id);
    }
}
