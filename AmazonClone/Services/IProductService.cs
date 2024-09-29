using AmazonClone.Models;

namespace AmazonClone.Services
{
    public interface IProductService
    {
        Task<bool> Create(Products product);
        Task<IEnumerable<Products>> GetProducts();

        Task<Products?> GetProductById(int id);
        Task<bool> UpdateProduct(Products state);
        Task<bool> DeleteProduct(Products state);
    }
}
