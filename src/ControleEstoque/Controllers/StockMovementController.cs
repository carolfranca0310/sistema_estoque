using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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


    }
}
