using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;

namespace InventoryManagement.Domain.Interfaces.IService
{
    public interface IProductInfoService
    {
        Task<ProductInfoDTO?> CreateAsync(ProductInfoCreateDTO productInfo);
        Task<ProductInfoDTO?> GetByIdAsync(int id);
    }
}
