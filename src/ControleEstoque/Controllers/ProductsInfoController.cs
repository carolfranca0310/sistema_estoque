using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsInfoController : ControllerBase
    {
        private readonly IProductInfoService _productInfoService;
        public ProductsInfoController(IProductInfoService productInfoService)
        {
            _productInfoService = productInfoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductInfoCreateDTO productInfo)
        {
            if (productInfo == null) return BadRequest(new { message = "Payload inválido." });

            try
            {
                var created = await _productInfoService.CreateAsync(productInfo);

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidProductInfoException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro interno." });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foundedProductInfo = await _productInfoService.GetByIdAsync(id);

            if (foundedProductInfo == null)
                return NotFound(new {message = "Produto não encontrado" });

            return Ok(foundedProductInfo);
        }

        [HttpGet("productInfo/{productId:int}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var productInfos = await _productInfoService.GetByProductIdAsync(productId);

            if (productInfos == null || !productInfos.Any()) 
                return NotFound();

            return Ok(productInfos);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsInfo = await _productInfoService.GetAllProductsInfoAsync();

            if (!productsInfo.Any())
                return NotFound((new { message = "Nenhum produto encontrado." }));


            return Ok(productsInfo);
        }

    }
}
