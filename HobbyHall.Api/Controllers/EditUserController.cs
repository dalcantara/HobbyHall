using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HobbyHall.Api.Models;
using HobbyHall.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHall.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class EditUserController: ControllerBase
    {
        private readonly IMutableUserRepository _userRepository;

        public EditUserController(IMutableUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST api/values
        [HttpPost]
        public Task<User> Post([FromBody] User NewUser)
        {
            return _userRepository.Create(new User { });
        }

        // PUT api/values/5
        [HttpPut("{username}")]
        public Task<User> Put(string Username, [FromBody] User UpdatedUser)
        {
            return _userRepository.Update(Username, new User { });
        }

        // DELETE api/values/5
        [HttpDelete("{username}")]
        public void Delete(string Username)
        {
            _userRepository.Delete(Username);
        }
    }
}
