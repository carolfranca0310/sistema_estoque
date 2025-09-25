using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Service.Services;
using Moq;

namespace InventoryManagement.Tests.Teste.Service
{
    public class ProductsInfoServiceTests
    {
        private readonly Mock<IProductInfoRepository> _productInfoRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductInfoService _productInfoService;

        public ProductsInfoServiceTests()
        {
            _productInfoRepositoryMock = new Mock<IProductInfoRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();

            _productInfoService = new ProductInfoService(
                _productInfoRepositoryMock.Object,
                _productRepositoryMock.Object
            );
        }
    }
}

