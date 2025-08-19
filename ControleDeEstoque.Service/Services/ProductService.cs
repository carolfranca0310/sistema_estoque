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
            throw new NotImplementedException();
        }
    }
}
