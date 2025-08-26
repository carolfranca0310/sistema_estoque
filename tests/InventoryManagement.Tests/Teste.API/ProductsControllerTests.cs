using InventoryManagement.API.Controllers;
using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InventoryManagement.Tests.Teste.API
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _serviceMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _serviceMock = new Mock<IProductService>();

            _controller = new ProductsController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnSuccess()
        {
            //Arrange
            int id = Faker.RandomNumber.Next(10);

            var foundProduct = new ProductDTO
            {
                Id = id,
                Name = Faker.Lorem.Sentence(),
                ExpirationDate = DateTime.UtcNow.AddMonths(3),
                PurchaseDate = DateTime.UtcNow,
            };

            _serviceMock.Setup(m => m.GetAsync(id)).ReturnsAsync(foundProduct);

            //Act
            var result = await _controller.Get(id);

            //Asserts
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnNotFound()
        {
            //Arrange
            int id = Faker.RandomNumber.Next(10);

            ProductDTO? foundProduct = null;

            _serviceMock.Setup(m => m.GetAsync(id)).ReturnsAsync(foundProduct);

            //Act
            var result = await _controller.Get(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
