using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Infra.Context;

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
    }
}
