using InventoryManagement.Domain.DTO.StockMovement;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Interfaces.IService
{
    public interface IStockMovementService
    {
        Task<List<StockMovementDTO>> GetProductMovementsByProductInfoIdAsync(int productInfoId, MovementType? movementType);
        Task<StockMovementDTO> UpdateRegisterMovementAsync(int productInfoId, StockMovementUpdateDTO updateDto);
    }
}
