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
        private readonly DBContext DbContext;
        private readonly ICategory CategoryService;

        public CategoryController(DBContext dbContext)
        {
            this.DbContext = dbContext;
            CategoryService = new CategoryService(dbContext);
        }

        [HttpPost(Name = "Add")]
        public IActionResult AddCategoryController(CategoryRequestDTO requestDTO)
        {

            IActionResult result;

            try
            {
                CategoryService.AddCategory(requestDTO);
                result = StatusCode(200);
            }
            catch (Exception ex)
            {
                result = StatusCode(500);
            }

            return result;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> ListCategoriesAsync()
        {
            IActionResult result = null;

            try
            {
                List<Category> categories = await CategoryService.GetCategoriesAsync();
                result = Ok(categories);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
