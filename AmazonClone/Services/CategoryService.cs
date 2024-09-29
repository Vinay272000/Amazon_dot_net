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
        public ILogger<CategoryService> _log;
        public CategoryService(AmazonDbContext amazonDbContext, ILogger<CategoryService> log)
        {
            _AmazonDbContext = amazonDbContext;
            _log = log;
        }

        public async Task<bool> create(Category category)
        {
            try
            {
                _AmazonDbContext.categories?.Add(category);
                int entries = await _AmazonDbContext.SaveChangesAsync();
                return entries > 0;
            }
            catch(Exception ex)
            {
                _log.LogError(ex, $"create({category})");
                return false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                if (_AmazonDbContext.categories != null)
                {
                    _AmazonDbContext.categories.Remove(_AmazonDbContext.categories.Find(id));
                    int deletedId = await _AmazonDbContext.SaveChangesAsync();
                    return deletedId >  0 ;
                }
                return false;
            }
            catch(Exception ex ) 
            {
                _log.LogError(ex, $"DeleteById({id})");
                return false;
            }
           
        }

        public async Task<IEnumerable<Category>> Get()
        {
            try
            {
                return await _AmazonDbContext.categories.ToListAsync();
            }catch(Exception ex)
            {
                _log.LogError(ex, $"Get()");
                return Enumerable.Empty<Category>();
            }
        }

        public async Task<Category> GetById(int id)
        {
            try
            {
                if (_AmazonDbContext.categories != null)
                {
                    return await _AmazonDbContext.categories.FindAsync(id);
                }
                return null;
            }
            catch(Exception ex ) 
            {
                _log.LogError(ex, $"GetById({id})");
                return null;
            }
        }
        public async Task<bool> Update(Category category)
        {
            try
            {
                if (_AmazonDbContext.categories != null)
                {
                    Category existingCategory = await _AmazonDbContext.categories.FindAsync(category.CategoryId);
                    if (existingCategory != null)
                    {
                        existingCategory.CategoryName = category.CategoryName;
                        int entries = _AmazonDbContext.SaveChanges();
                        return entries  > 0;
                    }
                }
                return false;
            }
            catch(Exception ex ) 
            {
                _log.LogError(ex, $"Update({category}");
                return false;
            }
        }
    }
}
