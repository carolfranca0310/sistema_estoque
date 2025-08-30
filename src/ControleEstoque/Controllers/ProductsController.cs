using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Interfaces.IService;
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
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO product)
        {
            ProductDTO? savedProduct = await _productService.CreateAsync(product);

            if (savedProduct == null)
                return BadRequest("Erro ao salvar produto");

            return Ok(savedProduct);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var foundProduct = await _productService.GetAsync(id);

            if (foundProduct == null)
            {
                return NotFound(new { message = "Esse ID não existe" });
            }

            return Ok(foundProduct);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();


            return Ok(products);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDTO? updatedProduct)
        {
            if (updatedProduct == null)
                return BadRequest(new { message = "Dados inválidos." });

            var product = await _productService.UpdateAsync(id, updatedProduct);

            if (product == null)
                return NotFound(new { message = "Produto não encontrado." });

            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedProduct = await _productService.DeleteAsync(id);
            if (!deletedProduct)
                return NotFound(new { message = "Nenhum produto encontrado" });

            return Ok(new { message = "Produto apagado!" });
        }

    }
}
