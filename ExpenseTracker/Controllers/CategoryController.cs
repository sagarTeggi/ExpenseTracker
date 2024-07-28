using ExpenseTracker.Dto;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;

namespace ExpenseTracker.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DBContext dbContext;

        public CategoryController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost(Name = "Add")]
        public IActionResult AddCategoryController(CategoryRequestDTO requestDTO)
        {

            IActionResult result;

            try
            {
                var obj = new Category()
                {
                    Id = requestDTO.Id,
                    CategoryName = requestDTO.CategoryName,
                    CreatedTime = DateTime.UtcNow,
                    UpdateTime = null
                    
                };
                //result = OK(CategoryService.AddCategory());
                dbContext.Category.Add(obj);
                dbContext.SaveChanges();
                result = StatusCode(200);
            }
            catch (Exception ex)
            {
                result = StatusCode(500);
            }

            return result;
        }
    }
}
