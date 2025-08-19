using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Interfaces.IService
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetAsync(int id);

    }
}
