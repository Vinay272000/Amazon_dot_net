using AmazonClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Services
{
    public interface ICategoryService
    {
       Task<IEnumerable<Category>>  Get();

        Task<Category> GetById(int id);

        Task<IActionResult> DeleteById(int id);

        Task<IActionResult> Update(Category category);

        Task<IActionResult> create(int categoryId, string categoryName);

    }
}
