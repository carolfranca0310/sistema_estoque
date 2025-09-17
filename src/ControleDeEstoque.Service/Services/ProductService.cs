using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Domain.Setup;
using System.Linq.Expressions;

namespace InventoryManagement.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        private async Task ValidateProduct(Expression<Func<Product, bool>> predicate)
        {

            var existingProduct = await _repository
                .CheckingExistingProductAsync(predicate);

            if (existingProduct != null)
            {
                throw new ConflictException("Já existe um produto com mesmo nome, marca e peso.");
            }
        }

        public async Task<ProductDTO?> CreateAsync(ProductCreateDTO productCreate)
        {
            await ValidateProduct(p => 
            p.Name.ToLower() == productCreate.Name.ToLower() &&
            p.Brand.ToLower() == productCreate.Brand.ToLower() &&
            p.Weight == productCreate.Weight);

            var product = AutoMapperConfig.ProductCreateDTOFromEntity(productCreate);

            var productDTO = AutoMapperConfig.ProductFromDTO(await _repository.CreateAsync(product));

            return productDTO;
        }

        public async Task<ProductDTO?> GetAsync(int id)
        {
            var productEntity = await _repository.GetAsync(id);

            if (productEntity == null)
                return null;

            var productDTO = AutoMapperConfig.ProductFromDTO(productEntity);
            return productDTO;
        }

        public async Task<List<ProductDTO>?> GetAllAsync()
        {
            var productEntity = await _repository.GetAllAsync();

            var productDTO = productEntity
                .Select(p => AutoMapperConfig.ProductFromDTO(p))
                .ToList();
            return productDTO;
        }

        public async Task<ProductDTO?> UpdateAsync(int id, ProductUpdateDTO updatedProduct)
        {
            var foundProduct = await _repository.GetAsync(id);

            if (foundProduct == null)
                return null;

            await ValidateProduct(p =>
               p.Name.ToLower() == updatedProduct.Name.ToLower() &&
               p.Brand.ToLower() == updatedProduct.Brand.ToLower() &&
               p.Weight == updatedProduct.Weight &&
               p.Id != foundProduct.Id);

            var product = AutoMapperConfig.ProductUpdateDTOFromEntity(updatedProduct);

            var productDTO = AutoMapperConfig.ProductFromDTO(await _repository.UpdateAsync(id, product));

            return productDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var foundProduct = await _repository.GetAsync(id);

            if (foundProduct == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
