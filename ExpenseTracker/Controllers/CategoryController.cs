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
    public class CategoryController(CategoryService categoryService) : Controller
    {
         private static ILogger _logger { get => ExpenseTrackerLoggerFactory.GetStaticLogger<CategoryController>(); }
        private readonly CategoryService _categoryService = categoryService;

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult Get()
        { 
            IActionResult result;
            try
            {
                result = Ok (_categoryService.GetAllCategories());

            }
            catch(Exception ex)
            {
                _logger.LogError("Error occured while trying to fetch Categories. ErrorMsg: {ex.InnerException}", ex.InnerException);
                result = StatusCode(500);
                
            }
            return result;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddCategoryController(Category request)
        {
            IActionResult result;
            try
            {
                _categoryService.AddCategory(request);
                result = Ok("Category added successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occured while trying to add Category {categoryName}. ErrorMsg: {ex.InnerException}", request.CategoryName,ex.InnerException);
                result = StatusCode(500);
            }

            return result;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategoryControllerAsync(Category request)
        {
            IActionResult result;
            try
            {
                await _categoryService.UpdateCategoryAsync(request);
                result = Ok("Category updated successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occured while trying to Update Category {ID}. ErrorMsg: {ex.InnerException}", request.Id, ex.InnerException);
                result = StatusCode(500);
            }

            return result;
        }
     
    }
}
