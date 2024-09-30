using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ExpenseTracker.Models;
using ExpenseTracker.Data;

namespace ExpenseTracker.Service
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> _categoriesCollection;

        public CategoryService(IOptions<MongoDBSettings> dbSettings)
        {
            var mongoClient = new MongoClient(
                dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSettings.Value.DatabaseName);

            _categoriesCollection = mongoDatabase.GetCollection<Category>(
                dbSettings.Value.CollectionName);
        }

            public async Task<List<Category>> GetAsync() =>
                await _categoriesCollection.Find(_ => true).ToListAsync();        

    }
}
