using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HobbyHall.Api.Models;
using HobbyHall.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHall.Api.Controllers
{
    public class EditUserController: ControllerBase
    {
        private readonly IMutableUserRepository _userRepository;

        public EditUserController(IMutableUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // POST api/values
        [HttpPost]
        public Task<User> Post([FromBody] string value)
        {
            return _userRepository.Create(new User { });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Task<User> Put(int id, [FromBody] string value)
        {
            return _userRepository.Update(new User { });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
