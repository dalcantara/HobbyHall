using HobbyHall.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyHall.Api.Repositories
{
    public class MongoUserRepository: IReadOnlyUserRepository, IMutableUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public MongoUserRepository(IUserDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);  
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users =  _users.Find(user => true).ToEnumerable<User>();
            return await Task.FromResult(users);
        }

        public async Task<User> GetByUsernameAsync(string Username)
        {
            var user = _users.Find<User>(user => user.UserName == Username).FirstOrDefault();
            return await Task.FromResult(user);
        }

        public async Task<User> CreateAsync(User User)
        {
            _users.InsertOne(User);
            return await Task.FromResult<User>(User);
        }

        public async Task<User> UpdateAsync(string Username, User UpdatedUser)
        {
            var result = _users.ReplaceOne(user => user.UserName == Username, UpdatedUser);
            if (result.ModifiedCount > 0)
            {
                return await Task.FromResult(UpdatedUser);
            }
            return await Task.FromException<User>(new KeyNotFoundException(string.Format("Username: {0} was not found", Username)));
        }

        public void Delete(string Username)
        {
            _users.DeleteOne(user => user.UserName == Username);
        }
    }
}
