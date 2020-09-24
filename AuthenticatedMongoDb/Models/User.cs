using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AuthenticatedMongoDb.Models
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address PrimaryAddress { get; set; }

        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
