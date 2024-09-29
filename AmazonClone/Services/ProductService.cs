using AmazonClone.Context;
using AmazonClone.Models;
using Microsoft.EntityFrameworkCore;

namespace AmazonClone.Services
{
    public class ProductService : IProductService
    {
        public AmazonDbContext _AmazonDbContext;
        public ILogger<CategoryService> _log;
        public ProductService(AmazonDbContext amazonDbContext, ILogger<CategoryService> log)
        {
            _AmazonDbContext = amazonDbContext;
            _log = log;
        }
        public async Task<bool> Create(Products product)
        {
            try
            {
                _AmazonDbContext.products?.Add(product);
                int entries = await _AmazonDbContext.SaveChangesAsync();
                return entries > 0;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"create({product})");
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Products product)
        {
            try
            {
                if (_AmazonDbContext.products != null)
                {
                    _AmazonDbContext.products.Remove(_AmazonDbContext.products.Find(product.ProductId));
                    int deletedId = await _AmazonDbContext.SaveChangesAsync();
                    return deletedId > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"DeletePdroduct({product})");
                return false;
            }
        }

        public async Task<Products?> GetProductById(int id)
        {
            try
            {
                if (_AmazonDbContext.products != null)
                {
                    return await _AmazonDbContext.products.FindAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"GetProductById({id})");
                return null;
            }
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            try
            {
                return await _AmazonDbContext.products.ToListAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"GetProduct()");
                return Enumerable.Empty<Products>();
            }
        }

        public Task<bool> UpdateProduct(Products state)
        {
            throw new NotImplementedException();
        }
    }
}
