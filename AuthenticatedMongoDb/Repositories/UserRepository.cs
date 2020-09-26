using AuthenticatedMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatedMongoDb.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(string collectionName = "Users") : base(collectionName)
        {
        }

        public User GetByUsername(string Username)
        {
            var filter = Builders<User>.Filter.Eq("Username", Username);
            
            return Collection.Find(filter).FirstOrDefault();
        }

        public void UpdateFirstName(Guid Id, string FirstName)
        {
            var filter = Builders<User>.Filter.Eq("Id", Id);
            var updatedRecord = Builders<User>.Update.Set("FirstName", FirstName);

            Collection.UpdateOne(filter, updatedRecord);
        }
    }
}
