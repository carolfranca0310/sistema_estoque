using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;

namespace InventoryManagement.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<Product> CreateAsync(Product product)
        {
            return _repository.CreateAsync(product);
        }

        public Task<Product> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> UpdateAsync(int id, Product updatedProduct)
        {
            return await _repository.UpdateAsync(id, updatedProduct);
        }

        public async Task<Product> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
