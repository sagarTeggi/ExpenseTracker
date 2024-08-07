using ExpenseTracker.Data;
using ExpenseTracker.Models;

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

    }
}
