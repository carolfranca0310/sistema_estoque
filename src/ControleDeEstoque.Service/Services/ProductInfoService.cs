using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.Product;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Domain.Setup;

namespace InventoryManagement.Service.Services
{
    public class ProductInfoService : IProductInfoService
    {
        private readonly IProductInfoRepository _repository;
        private readonly IProductRepository _productRepository;

        public ProductInfoService(IProductInfoRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<ProductInfoDTO?> CreateAsync(ProductInfoCreateDTO productInfo)
        {
            var existentProduct = await _productRepository.CheckingExistingProductAsync(p => p.Id == productInfo.ProductId) ?? 
                                  throw new NotFoundException($"Produto com ID {productInfo.ProductId} não encontrado.");

            if (productInfo == null)
                throw new ArgumentNullException(nameof(productInfo));

            if(productInfo.ExpirationDate.Date < DateTime.UtcNow.Date)
                throw new Exception("A data de validade não pode ser menor que hoje.");

            if(productInfo.Quantity <= 0)
                throw new Exception("A quantidade deve ser maior que zero.");

            var entity = AutoMapperConfig.ProductInfoCreateDTOFromEntity(productInfo);

            var created = await _repository.CreateAsync(entity);

            var productDTO = AutoMapperConfig.ProductInfoEntityFromInfoDTO(created);

            return productDTO;
        }

        public async Task<List<ProductInfoDTO>> GetAllProductsInfoAsync()
        {
            var productInfoEntity = await _repository.GetAllProductsInfoAsync();

            var productInfoDTO = productInfoEntity
                .Select(p => AutoMapperConfig.ProductInfoEntityFromInfoDTO(p))
                .ToList();

            return productInfoDTO;
        }

        public async Task<ProductInfoDTO?> GetByIdAsync(int id)
        {
            var productInfoEntity = await _repository.GetByIdAsync(id);

            if (productInfoEntity == null)
                return null;
            var productInfoDTO = AutoMapperConfig.ProductInfoEntityFromInfoDTO(productInfoEntity);
            return productInfoDTO;
        }
        public async Task<List<ProductInfoDTO>> GetByProductIdAsync(int productId)
        {
            List<ProductInfo> productInfoEntity = await _repository.GetByProductIdAsync(productId);

            if (productInfoEntity == null)
                return [];

            var productInfoDTO = productInfoEntity
                .Select(p => AutoMapperConfig.ProductInfoEntityFromInfoDTO(p))
                .ToList();

            return productInfoDTO;
        }

        public async Task<ProductInfoDTO> UpdateAsync(int id, ProductInfoUpdateDTO updatedProductInfo)
        {
            var existentProduct = await _productRepository.CheckingExistingProductAsync(p => p.Id == updatedProductInfo.ProductId) ??
                                  throw new NotFoundException($"Produto com ID {updatedProductInfo.ProductId} não encontrado.");

            var foundProduct = await _repository.GetByIdAsync(id);

            if (foundProduct == null)
                return null;

            var productInfo = AutoMapperConfig.ProductInfoUpdateDTOFromEntity(updatedProductInfo);

            var productDTO = AutoMapperConfig.ProductInfoEntityFromInfoDTO(await _repository.UpdateAsync(id, productInfo));

            return productDTO;
        }
    }
}
