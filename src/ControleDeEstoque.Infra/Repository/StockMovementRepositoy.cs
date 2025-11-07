using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infra.Repository
{
    internal class StockMovementRepository : IStockMovementRepository
    {
        private readonly InventoryContext _context;

        public StockMovementRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<List<StockMovement>> GetProductMovementsByProductInfoIdAsync(int productInfoId, MovementType? movementType)
        {
            var query = _context.StockMovement
                        .Where(s => s.ProductInfoId == productInfoId);

            if (movementType != null)
            {
                query = query.Where(s => s.MovementType == movementType);
            }
            
            return await query.ToListAsync();
        }      
    }
}
