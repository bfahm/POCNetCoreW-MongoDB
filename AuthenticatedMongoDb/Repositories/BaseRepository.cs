using AuthenticatedMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatedMongoDb.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected IMongoDatabase db;
        protected static string CollectionName;
        protected IMongoCollection<T> Collection;

        public BaseRepository(string collectionName)
        {
            CollectionName = collectionName;
            
            db = new DBConfig().db;
            Collection = db.GetCollection<T>(CollectionName);
        }

        public void InsertRecord(T record)
        {
            Collection.InsertOne(record);
        }

        public List<T> GetAll()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public T GetById(Guid Id)
        {
            var filter = Builders<T>.Filter.Eq("Id", Id);

            return Collection.Find(filter).FirstOrDefault();
        }

        public void DeleteById(Guid Id)
        {
            var filter = Builders<T>.Filter.Eq("Id", Id);

            Collection.DeleteOne(filter);
        }

        public void DeleteAll()
        {
            Collection.DeleteMany(new BsonDocument());
        }
    }
}
