using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetAsync(int id);
    }
}
