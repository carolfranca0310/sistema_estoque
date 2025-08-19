using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            Product savedProduct = await _productService.CreateAsync(product);
            return Ok(savedProduct);
        }
    }
}
