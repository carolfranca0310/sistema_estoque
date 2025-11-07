using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.DTO.StockMovement;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IStockMovementRepository
    {
        Task<List<StockMovement>> GetProductMovementsByProductInfoIdAsync(int productInfoId, MovementType? movementType);
        Task<StockMovement> UpdateRegisterMovementAsync(int productInfoId, StockMovementUpdateDTO updateDto);
        Task AddAsync(StockMovement stockMovement);
    }
}
