using InventoryManagement.API.Controllers;
using InventoryManagement.Domain.DTO.Product;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System.Net;

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

        [Fact]
        public async Task CreateProducts_ShouldReturnConflict_WhenConflictExceptionThrown()
        {
            // Arrange
            var newProduct = new ProductCreateDTO
            {
                Name = "Produto teste",
                Brand = Faker.Lorem.Sentence(),
                Weight = Faker.RandomNumber.Next(10),
            };

            _serviceMock.Setup(m => m.CreateAsync(newProduct)).ThrowsAsync(new ConflictException("Produto já existe"));

            // Act
            var result = await _controller.Create(newProduct);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.Conflict, objectResult.StatusCode);
            Assert.Equal("Produto já existe", objectResult.Value);
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
            var newProductList = new List<ProductDTO>
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

            _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(newProductList);

            //Act
            var result = await _controller.GetAll();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnNotFound_WhenNoProductsExist()
        {
            // Arrange
            var emptyProductsList = new List<ProductDTO>();

            _serviceMock
                .Setup(m => m.GetAllAsync())
                .ReturnsAsync(emptyProductsList);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var value = notFoundResult.Value;

            var messageProperty = value.GetType().GetProperty("message")?.GetValue(value, null);

            Assert.Equal("Nenhum produto encontrado.", messageProperty);
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

        [Fact]
        public async Task UpdateProducts_ShouldReturnConflict_WhenConflictExceptionThrown()
        {
            // Arrange
            int productId = Faker.RandomNumber.Next(10);

            var updatedProduct = new ProductUpdateDTO();

            _serviceMock
                .Setup(m => m.UpdateAsync(productId, It.IsAny<ProductUpdateDTO>()))
                .ThrowsAsync(new ConflictException("Conflito ao atualizar o produto."));

            // Act
            var result = await _controller.Update(productId, updatedProduct);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.Conflict, objectResult.StatusCode);
            Assert.Equal("Conflito ao atualizar o produto.", objectResult.Value);
        }

        #endregion
    }
}
