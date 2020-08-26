using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HobbyHall.Api.Models;
using HobbyHall.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HobbyHall.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/values
        [HttpGet]
        public Task<IEnumerable<User>> List()
        {
            return _userRepository.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<User> GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
