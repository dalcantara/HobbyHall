using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HobbyHall.Api.Models;

namespace HobbyHall.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>>  GetAllAsync();
        Task<User>  GetById(int userId);
    }
}
