using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.DTO.StockMovement;
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
        public async Task AddAsync(StockMovement stockMovement)
        {
            await _context.StockMovement.AddAsync(stockMovement);
            await _context.SaveChangesAsync();
        }

        public async Task<StockMovement> UpdateRegisterMovementAsync(int productInfoId, StockMovementUpdateDTO updateDto)
        {
            var existingMovement = await _context.StockMovement
                .FirstOrDefaultAsync(sm => sm.ProductInfoId == productInfoId);

            if (existingMovement == null)
            {
                throw new KeyNotFoundException($"StockMovement with ProductInfoId {productInfoId} not found.");
            }

            existingMovement.Quantity = updateDto.Quantity;

            _context.StockMovement.Update(existingMovement);
            await _context.SaveChangesAsync();

            return existingMovement;
        }
    }
}
