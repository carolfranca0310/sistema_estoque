using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IProductInfoRepository
    {
        Task<ProductInfo?> CreateAsync(ProductInfo productInfo);
        Task<ProductInfo?> GetByIdAsync(int id);
        Task<List<ProductInfo>> GetByProductIdAsync(int productId);
        Task<List<ProductInfo>> GetAllProductsInfoAsync();
    }
}
