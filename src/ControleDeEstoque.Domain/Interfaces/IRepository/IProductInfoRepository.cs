using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IProductInfoRepository
    {
        Task<ProductInfo?> CreateAsync(ProductInfo productInfo);
        Task<ProductInfo?> GetByIdAsync(int id);
        Task<List<ProductInfo>> GetByProductIdAsync(int productId, Status status);
        Task<List<ProductInfo>> GetAllProductsInfoAsync();
        Task<ProductInfo> UpdateAsync(int id, ProductInfo updatedProductInfo);
    }
}
