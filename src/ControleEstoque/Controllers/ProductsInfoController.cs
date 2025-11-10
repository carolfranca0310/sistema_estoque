using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

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

                return Ok(created);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foundedProductInfo = await _productInfoService.GetByIdAsync(id);

            if (foundedProductInfo == null)
                return NotFound(new {message = "Produto não encontrado" });

            return Ok(foundedProductInfo);
        }

        [HttpGet("productInfo/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId, [FromQuery, Required] Status status)
        {
            var productInfos = await _productInfoService.GetByProductIdAsync(productId, status);

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


        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductInfoUpdateDTO? updatedProductInfo)
        {
            try
            {
                if (updatedProductInfo == null)
                    return BadRequest(new { message = "Dados inválidos." });

                var productInfo = await _productInfoService.UpdateAsync(id, updatedProductInfo);

                if (productInfo == null)
                    return NotFound(new { message = "Produto não encontrado." });

                return Ok(productInfo);
            }
            catch (ConflictException ex)
            {

                return StatusCode((int)HttpStatusCode.Conflict, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/inactivate")]
        public async Task<ActionResult> InactivateAsync(int id, [FromBody] string justification)
        {
            var result = await _productInfoService.InactivateAsync(id, justification);
            return Ok(new { message = "Produto inativado!" });
        }
    }
}
