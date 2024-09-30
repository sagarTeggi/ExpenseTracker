using ExpenseTracker.Dto;
using ExpenseTracker.Models;

namespace ExpenseTracker.Interface
{
    public interface ICategory
    {
        public List<Category> GetAllCategories();

        public void AddCategory(Category category);
    }
}
