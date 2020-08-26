using System;
namespace HobbyHall.Api.Models
{
    public class Address
    {
        public Address()
        {
        }
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }

    }
}
