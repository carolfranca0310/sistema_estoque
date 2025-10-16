using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IService
{
    public interface IProductInfoService
    {
        Task<ProductInfoDTO?> CreateAsync(ProductInfoCreateDTO productInfo);
        Task<ProductInfoDTO?> GetByIdAsync(int id);
        Task<List<ProductInfoDTO>> GetByProductIdAsync(int productId);
        Task<List<ProductInfoDTO>> GetAllProductsInfoAsync();
        Task<ProductInfoDTO> InactivateAsync(int id, string justification);
        Task<ProductInfoDTO> UpdateAsync(int id, ProductInfoUpdateDTO updatedProductInfo);
    }
}
