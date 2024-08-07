using ExpenseTracker.Dto;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Service;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly DBContext dbContext;
        private readonly ICategory category;

        public CategoryController(DBContext dbContext)
        {
            this.dbContext = dbContext;
            category = new CategoryService(dbContext);
        }

        [HttpPost(Name = "Add")]
        public IActionResult AddCategoryController(CategoryRequestDTO requestDTO)
        {

            IActionResult result;

            try
            {
                category.AddCategory(requestDTO);
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
