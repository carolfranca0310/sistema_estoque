using InventoryManagement.API.Controllers;
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
        #endregion

        #region GetByProductId
        #endregion

        #region Create
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

    }
}
