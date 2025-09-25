using InventoryManagement.API.Controllers;
using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InventoryManagement.Tests.Teste.API
{
    public class ProductsInfoControllerTests
    {
        private readonly Mock<IProductInfoService> _serviceMock;
        private readonly ProductsInfoController _controller;

        public ProductsInfoControllerTests()
        {
            _serviceMock = new Mock<IProductInfoService>();

            _controller = new ProductsInfoController(_serviceMock.Object);
        }

        #region Get
        [Fact]
        public async Task GetProductsInfo_ShouldReturnSucess()
        {
            int id = Faker.RandomNumber.Next(1, 100);
            int productId = Faker.RandomNumber.Next(1, 100);

            var foundProductInfo = new ProductInfoDTO
            {
                Id = id,
                ProductId = productId,
                PurchaseDate = DateTime.UtcNow.AddDays(-10),
                ExpirationDate = DateTime.UtcNow.AddDays(20),
                Quantity = 5,
                UnitPrice = 10.0m,
                TotalPrice = 50.0m
            };

            _serviceMock.Setup(m => m.GetByIdAsync(id)).ReturnsAsync(foundProductInfo);

            var result = await _controller.GetById(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetProductsInfo_ShouldNotFound()
        {
            int id = Faker.RandomNumber.Next(10);

            ProductInfoDTO foundedProductInfo = null;

            _serviceMock.Setup(m => m.GetByIdAsync(id)).ReturnsAsync(foundedProductInfo);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundObjectResult>(result);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAllProductsInfo_ShouldReturnSucess()
        {
            var newProductsInfoList = new List<ProductInfoDTO>
            {
                new ProductInfoDTO
                {
                    Id = Faker.RandomNumber.Next(10),
                    ProductId = Faker.RandomNumber.Next(10),
                    PurchaseDate = DateTime.Now.AddDays(-10),
                    ExpirationDate = DateTime.Now.AddDays(20),
                    Quantity = 5,
                    UnitPrice = 10.5m,
                    TotalPrice = 52.5m
                },

                new ProductInfoDTO()
            };

            _serviceMock.Setup(m => m.GetAllProductsInfoAsync()).ReturnsAsync(newProductsInfoList);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNotFound()
        {
            var emptyProductsInfoList = new List<ProductInfoDTO>();

            _serviceMock
                .Setup(m => m.GetAllProductsInfoAsync())
                .ReturnsAsync(emptyProductsInfoList);

            var result = await _controller.GetAll();

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var value = notFoundResult.Value;

            var messageProperty = value.GetType().GetProperty("message")?.GetValue(value, null);

            Assert.Equal("Nenhum produto encontrado.", messageProperty);
        }
        #endregion

        #region GetByProductId
        [Fact]
        public async Task GetByProductId_ShouldReturnSucess()
        {
            int productId = 1;
            var productInfos = new List<ProductInfoDTO>
        {
            new ProductInfoDTO { Id = 1, ProductId = productId}
        };

            _serviceMock.Setup(s => s.GetByProductIdAsync(productId))
                        .ReturnsAsync(productInfos);

            var result = await _controller.GetByProductId(productId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<ProductInfoDTO>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetByProductId_ReturnsNotFound()
        {
            int productId = 1;
            _serviceMock.Setup(s => s.GetByProductIdAsync(productId))
                        .ReturnsAsync(new List<ProductInfoDTO>());

            var result = await _controller.GetByProductId(productId);

            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_ShouldReturnSucess()
        {
            var dto = new ProductInfoCreateDTO
            {
                ProductId = 1,
                PurchaseDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(10),
                Quantity = 5,
                UnitPrice = 10m
            };

            var createdEntity = new ProductInfoDTO();

            _serviceMock.Setup(m => m.CreateAsync(dto)).ReturnsAsync(createdEntity);

            var result = await _controller.Create(dto);

            var createdResult = Assert.IsType<OkObjectResult>(result);
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

    }
}
