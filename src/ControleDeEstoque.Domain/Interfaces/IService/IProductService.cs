using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IService
{
    public interface IProductService
    {
        Task<ProductDTO> CreateAsync(ProductCreateDTO product);
        Task<ProductDTO?> GetAsync(int id);
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> UpdateAsync(int id, ProductUpdateDTO updatedProduct);
        Task<bool> DeleteAsync(int id);

    }
}
