using InventoryManagement.API.Controllers;
using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

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

        #region Get
        [Fact]
        public async Task GetProducts_ShouldReturnSuccess()
        {
            //Arrange
            int id = Faker.RandomNumber.Next(10);

            var foundProduct = new ProductDTO
            {
                Id = id,
                Name = Faker.Lorem.Sentence(),
                Brand = Faker.Lorem.Sentence(),
                Weight = Faker.RandomNumber.Next(10),
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
        #endregion

        #region Create
        [Fact]
        public async Task CreateProducts_ShouldReturnSucess()
        {
            var newProduct = new ProductCreateDTO
            {
                Name = "Produto teste",
                Brand = Faker.Lorem.Sentence(),
                Weight = Faker.RandomNumber.Next(10),
            };

            var createdProduct = new ProductDTO();

            _serviceMock.Setup(m => m.CreateAsync(newProduct)).ReturnsAsync(createdProduct);

            var result = await _controller.Create(newProduct);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task CreateProducts_ShouldReturnBadRequest()
        {
            //Arrange
            var newProduct = new ProductCreateDTO
            {
                Name = "Produto teste",
                Brand = Faker.Lorem.Sentence(),
                Weight = Faker.RandomNumber.Next(10),
            };

            ProductDTO? createdProduct = null;

            _serviceMock.Setup(m => m.CreateAsync(newProduct)).ReturnsAsync(createdProduct);

            //Act
            var result = await _controller.Create(newProduct);

            //Asserts
            Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task DeleteProducts_ShoudReturnSucess()
        {
            //Arrange
            int id = Faker.RandomNumber.Next(10);
            var expected = new { message = "Produto atualizado com sucesso" };

            _serviceMock.Setup(m => m.DeleteAsync(id)).ReturnsAsync(true);

            //Act
            var result = await _controller.Delete(id);

            //Asserts
            var statusCode = Assert.IsType<OkObjectResult>(result);

            var resultValue = Assert.IsType<OkObjectResult>(result);

            var json = JsonConvert.SerializeObject(resultValue.Value);
            Assert.Contains("Produto apagado!", json);


        }
        [Fact]
        public async Task DeleteProducts_ShoudReturnNotFound()
        {
            //Arrange
            int id = 999;

            _serviceMock.Setup(m => m.DeleteAsync(id)).ReturnsAsync(false);

            //Act
            var result = await _controller.Delete(id);

            //Asserts
            Assert.IsType<NotFoundObjectResult>(result);

        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAllProducts_ShouldReturnSucess()
        {
            //Arrange
            var newListProduct = new List<ProductDTO>
            {
                 new ProductDTO
                 {
                    Id = Faker.RandomNumber.Next(10),
                    Name = "Produto Um",
                    Brand = Faker.Lorem.Sentence(),
                    Weight = Faker.RandomNumber.Next(10),
                 },

                new ProductDTO()
            };

            _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(newListProduct);

            //Act
            var result = await _controller.GetAll();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        #endregion

        #region Update
        [Fact]
        public async Task UpdateProducts_ShouldReturnSucess()
        {
            //Arrange
            int productId = Faker.RandomNumber.Next(10);

            var updatedProduct = new ProductUpdateDTO
            {
                Name = Faker.Lorem.Sentence(),
                Brand = Faker.Lorem.Sentence(),
                Weight = Faker.RandomNumber.Next(10),
            };

            var returnProduct = new ProductDTO();

            _serviceMock.Setup(m => m.UpdateAsync(productId, It.IsAny<ProductUpdateDTO>())).ReturnsAsync(returnProduct);

            //Act
            var result = await _controller.Update(productId, updatedProduct);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateProducts_ShouldReturnBadRequest()
        {
            //Arrange
            int productId = Faker.RandomNumber.Next(10);

            ProductUpdateDTO? updatedProduct = null;

            //Act
            var result = await _controller.Update(productId, updatedProduct);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateProducts_ShouldReturnNotFound()
        {
            //Arrange
            int productId = Faker.RandomNumber.Next(10);

            var updatedProduct = new ProductUpdateDTO();

            _serviceMock.Setup(m => m.UpdateAsync(productId, It.IsAny<ProductUpdateDTO>())).ReturnsAsync((ProductDTO?)null);

            //Act
            var result = await _controller.Update(productId, updatedProduct);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        #endregion
    }
}
