using AmazonClone.Models;
using AmazonClone.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public IProductService _productService;
        public ProductsController(IProductService productService) { _productService = productService; }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Products> product = await _productService.GetProducts();
            return product.Any() ? Ok(product) : BadRequest();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            Products product = await _productService.GetProductById(id);
            return product != null ? Ok(product) : BadRequest();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post(Products product)
        {
            bool isCreated = await _productService.Create(product);
            return isCreated ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(Products product)
        {
            bool isDeleted = await _productService.DeleteProduct(product);
            return isDeleted ? Ok() : BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(Products product)
        {
            bool isUpdated = await _productService.UpdateProduct(product);
            return isUpdated ? Ok() : BadRequest();
        }
    }
}  
