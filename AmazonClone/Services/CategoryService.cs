using AmazonClone.Context;
using AmazonClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AmazonClone.Services
{
    public class CategoryService : ICategoryService
    {
        public AmazonDbContext _AmazonDbContext;
        public CategoryService(AmazonDbContext amazonDbContext) {
            _AmazonDbContext= amazonDbContext;
        }

        public async Task<IActionResult> create(int categoryId, string categoryName)
        {
            try
            {
                _AmazonDbContext.categories?.Add(new Category { CategoryId = categoryId, CategoryName = categoryName});
                await _AmazonDbContext.SaveChangesAsync();
                return Ok(new { Message = "Category created successfully" });
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                _AmazonDbContext.categories?.Remove(_AmazonDbContext.categories.Find(id));
                await _AmazonDbContext.SaveChangesAsync();
                return Ok(Get());
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> Get()
        {
            try
            {
                return await _AmazonDbContext.categories.ToListAsync();
            }catch(Exception ex) {
                throw new NotImplementedException();
            }
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
