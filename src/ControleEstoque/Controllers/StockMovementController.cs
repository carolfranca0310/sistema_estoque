using InventoryManagement.Domain.DTO.StockMovement;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovementService _stockMovementService;

        public StockMovementController(IStockMovementService stockMovementService)
        {
            _stockMovementService = stockMovementService;
        }

        [HttpGet("stockMovement/{productInfoId:int}")]
        public async Task<IActionResult> GetProductMovementsByProductInfoId(int productInfoId, [FromQuery] MovementType? movementType)
        {
            var productInfos = await _stockMovementService.GetProductMovementsByProductInfoIdAsync(productInfoId, movementType);

            return Ok(productInfos);
        }

        [HttpPut("stockMovement/{productInfoId:int}")]
        public async Task<IActionResult> UpdateRegisterMovementAsync(int productInfoId, [FromBody] StockMovementUpdateDTO updateDto){
            if (updateDto == null)
                return BadRequest(new { message = "Dados inválidos" });

            try
            {
                var result = await _stockMovementService.UpdateRegisterMovementAsync(productInfoId, updateDto);
                return Ok(new
                {
                    message = "Movimentação registrada com sucesso.",
                    movement = result
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro interno ao registrar movimentação." });
            }
        }

    }
}
