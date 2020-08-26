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
    [ApiController]
    public class QueryUserController : ControllerBase
    {

        private readonly IReadOnlyUserRepository _userRepository;

        public QueryUserController(IReadOnlyUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null) {
                return NotFound(new EmptyResult());
            }
            return Ok(user);
        }
    }
}
