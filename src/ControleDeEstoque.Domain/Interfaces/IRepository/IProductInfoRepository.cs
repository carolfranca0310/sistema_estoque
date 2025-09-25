using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IProductInfoRepository
    {
        Task<ProductInfo?> CreateAsync(ProductInfo productInfo);
        Task<ProductInfo?> GetBydIdAsync(int id);
    }
}
