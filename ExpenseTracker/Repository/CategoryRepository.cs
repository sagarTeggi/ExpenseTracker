using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository
{
    public class CategoryRepository
    {
        private readonly DBContext dBContext;

        public CategoryRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public void AddCategory(Category category)
        {
            dBContext.Category.Add(category);
            dBContext.SaveChanges();
        }

        public async Task<List<Category>> FindAllCategoriesAsync()
        {
            var query = from Category category in dBContext.Category
                        select category;

            return await query.ToListAsync();
        }

    }
}
