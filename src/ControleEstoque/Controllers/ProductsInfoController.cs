using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IService;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

    }
}
