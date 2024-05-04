using AmazonClone.Context;
using AmazonClone.Models;
using AmazonClone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace AmazonClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _CatogoryService;
        public CategoryController(ICategoryService categoryService) {
            _CatogoryService= categoryService;
        }

        public async Task<IActionResult> Get() {
            return Ok(await _CatogoryService.Get());
        }

        public async Task<IActionResult> Post(int categoryId, string categoryName)
        {
            await _CatogoryService.create(categoryId, categoryName);
            return Ok();
        }

        public async Task<IActionResult> Delete(int categoryId)
        {
            
            return Ok(await _CatogoryService.DeleteById(categoryId));
        }

    }
}
