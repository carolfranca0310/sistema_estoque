using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IService
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<Product> UpdateAsync(int id, Product updatedProduct);
        Task<Product> DeleteAsync(int id);

    }
}
