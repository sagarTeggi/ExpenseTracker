﻿using ExpenseTracker.Data;
using ExpenseTracker.Dto;
using ExpenseTracker.Interface;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service
{
    public class CategoryService : ICategory
    {

        private readonly CategoryRepository CategoryRepository;

        private static ILogger _logger { get => ExpenseTrackerLoggerFactory.GetStaticLogger<CategoryService>(); }

        public CategoryService(DBContext dbContext) 
        {
            CategoryRepository = new CategoryRepository(dbContext);
        }

        public void AddCategory(CategoryRequestDTO requestDTO)
        {

            var newCategory = new Category()
            {
                CategoryName = requestDTO.CategoryName,
                CreatedTime = DateTime.UtcNow,
            };

            CategoryRepository.AddCategory(newCategory);
            _logger.LogInformation("New category added successfully");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> cateogryList = [];
            try
            {
                cateogryList = await CategoryRepository.FindAllCategoriesAsync();
                _logger.LogInformation("Categories found {count}", cateogryList.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while trying to fetch categories. Error msg: {ex}", ex.Message);
            }
                
            return cateogryList;
        }
    }
}
