using System;
using System.Collections.Generic;

namespace HobbyHall.Api.Models
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
