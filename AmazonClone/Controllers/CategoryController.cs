using AmazonClone.Context;
using AmazonClone.Models;
using AmazonClone.Services;
using AmazonClone.ViewModels;
using AutoMapper;
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
        public readonly IMapper _Imapper;

        public CategoryController(ICategoryService categoryService, IMapper Imapper) {
            _CatogoryService = categoryService;
            _Imapper = Imapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get() {
            IEnumerable<Category> categories = await _CatogoryService.Get();
            return categories.Any() ? Ok(categories) : BadRequest();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            Category category = await _CatogoryService.GetById(id);
            return category != null ? Ok(category) : BadRequest();
        }

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> create([FromBody]CategoryVM categoryVM)
        //{
        //    Category category = _Imapper.Map<Category>(categoryVM);
        //    bool isCreated = await _CatogoryService.create(category);
        //    return isCreated ? Ok(new {message = true}): BadRequest();
        //}

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            bool isDeleted = await _CatogoryService.DeleteById(categoryId);
            return isDeleted ? Ok() : BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(Category category)
        {
            bool isUpdated = await _CatogoryService.Update(category);
            return isUpdated ? Ok() : BadRequest();
        }
    }
}
