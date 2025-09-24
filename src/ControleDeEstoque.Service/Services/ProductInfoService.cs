using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Domain.Setup;
using Microsoft.EntityFrameworkCore.Metadata;

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
    }
}
