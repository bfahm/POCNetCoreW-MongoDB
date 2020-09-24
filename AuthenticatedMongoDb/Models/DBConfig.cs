using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatedMongoDb.Models
{
    public class DBConfig
    {
        private static string DatabaseName = "TestPOC";
        public IMongoDatabase db;

        public DBConfig()
        {
            var client = new MongoClient();
            db = client.GetDatabase(DatabaseName); // Get the database by its name if it exists, else create a new one
        }
    }
}
