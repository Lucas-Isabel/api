using api.Entities;
using MongoDB.Driver;

namespace api.DB
{
    public class ApiDBContext
    {
        private readonly IMongoDatabase _database;

        public ApiDBContext(IMongoClient mongoClient, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("Products");
            }
        }
    }
}
