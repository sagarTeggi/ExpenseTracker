using ExpenseTracker.Dto;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;

namespace ExpenseTracker.Interface
{
    public interface ICategory
    {
        public void AddCategory(CategoryRequestDTO requestDTO);

        public  Task<List<Category>> GetCategoriesAsync();
    }
}
