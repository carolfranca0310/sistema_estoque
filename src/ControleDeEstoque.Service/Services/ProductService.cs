using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Domain.Setup;

namespace InventoryManagement.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDTO> CreateAsync(ProductCreateDTO productCreate)
        {
            var product = AutoMapperConfig.ProductCreateDTOFromEntity(productCreate);

            var productDTO = AutoMapperConfig.ProductFromDTO(await _repository.CreateAsync(product));

            return productDTO;
        }

        public async Task<ProductDTO?> GetAsync(int id)
        {
            var productEntity = await _repository.GetAsync(id);

            var productDTO = AutoMapperConfig.ProductFromDTO(productEntity);
            return productDTO;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
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
