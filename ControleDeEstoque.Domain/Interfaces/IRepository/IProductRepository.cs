using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<Product> UpdateAsync(int id, Product updatedProduct);
        Task<Product> DeleteAsync(int id);

    }
}
