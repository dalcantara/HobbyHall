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
        public async Task<IActionResult> Post([FromBody] User NewUser)
        {
            var user = await _userRepository.CreateAsync(NewUser);
            return Ok(user); 
        }

        // PUT api/values/5
        [HttpPut("{username}")]
        public async Task<IActionResult> Put(string username, [FromBody] User UpdatedUser)
        {
            try
            {
                var updatedUser = await _userRepository.UpdateAsync(username, UpdatedUser);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException) {
                return NotFound(new EmptyResult());
            }

        }

        // DELETE api/values/5
        [HttpDelete("{username}")]
        public async void Delete(string Username)
        {
            _userRepository.Delete(Username);
        }
    }
}
