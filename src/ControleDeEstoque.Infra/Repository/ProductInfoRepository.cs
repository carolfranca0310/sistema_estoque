using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infra.Repository
{
    internal class ProductInfoRepository : IProductInfoRepository
    {
        private readonly InventoryContext _context;

        public ProductInfoRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<ProductInfo> CreateAsync(ProductInfo productInfo)
        {
            _context.ProductInfo.Add(productInfo);

            await _context.SaveChangesAsync();

            return productInfo;
        }

        public async Task<List<ProductInfo>> GetAllProductsInfoAsync()
        {
            return await _context.ProductInfo
                .ToListAsync();
        }

        public async Task<ProductInfo?> GetByIdAsync(int id)
        {
            return await _context.ProductInfo.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProductInfo>> GetByProductIdAsync(int id)
        {
            return await _context.ProductInfo
                        .Where(p => p.ProductId == id)
                        .ToListAsync();
        }

        public async Task<ProductInfo> UpdateAsync(int id, ProductInfo updatedProductInfo)
        {
            var productInfo = await GetByIdAsync(id);

            productInfo.ProductId = updatedProductInfo.ProductId;
            productInfo.UnitPrice = updatedProductInfo.UnitPrice;
            productInfo.Quantity = updatedProductInfo.Quantity;
            productInfo.ExpirationDate = updatedProductInfo.ExpirationDate;
            productInfo.PurchaseDate = updatedProductInfo.PurchaseDate;
            productInfo.RecalculateTotal();

            _context.ProductInfo.Update(productInfo);
            await _context.SaveChangesAsync();

            return productInfo;
        }
    }
}
