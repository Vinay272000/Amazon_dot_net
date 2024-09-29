using AmazonClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Services
{
    public interface ICategoryService
    {
       Task<IEnumerable<Category>>  Get();

        Task<Category> GetById(int id);

        Task<bool> DeleteById(int id);

        Task<bool> Update(Category category);

        Task<bool> create(Category category);

    }
}
