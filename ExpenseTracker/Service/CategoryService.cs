using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ExpenseTracker.Models;
using ExpenseTracker.Data;
using ExpenseTracker.Interface;

namespace ExpenseTracker.Service
{
    public class CategoryService: ICategory
    {
        private readonly IMongoCollection<Category> _categoriesCollection;
        private static ILogger _logger { get => ExpenseTrackerLoggerFactory.GetStaticLogger<CategoryService>(); }

        public CategoryService(IOptions<MongoDBSettings> dbSettings)
        {
            var mongoClient = new MongoClient(
                dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSettings.Value.DatabaseName);

            _categoriesCollection = mongoDatabase.GetCollection<Category>(
                dbSettings.Value.CollectionName);
        }

        public List<Category> GetAllCategories()
        {
            _logger.LogInformation("Fetching available categories");
            return _categoriesCollection.Find(_ => true).ToList();
        }
        
        public void AddCategory(Category request)
        {
            _logger.LogInformation("Adding category:{categoryName}",request.CategoryName);
            Category existingCategory = _categoriesCollection.Find(c => c.CategoryName.Equals(request.CategoryName)).FirstOrDefault();
            if(existingCategory is null)
            {
                _categoriesCollection.InsertOne(request);
            }
            else
            {
                _logger.LogInformation("{categoryName} already available! Skipping current category",request.CategoryName);
            }

        }
    }
}
