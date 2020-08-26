using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HobbyHall.Api.Models
{
    public class User
    {
        public User()
        {
        }
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
