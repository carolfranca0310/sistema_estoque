using InventoryManagement.Domain.Entity;
using System.Linq.Expressions;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<Product> UpdateAsync(int id, Product updatedProduct);
        Task DeleteAsync(int id);

        Task<Product?> CheckingExistingProductAsync(Expression<Func<Product, bool>> predicate);
    }
}
