using InventoryManagement.Domain.DTO.Product;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Service.Services;
using Moq;
using System.Linq.Expressions;

namespace InventoryManagement.Tests.Teste.Service
{
    public class ProductsServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly IProductService _productService;

        public ProductsServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }
        #region Create
        [Fact]
        public async Task CreateAsync_ShouldReturnProduct()
        {
            var productCreate = new ProductCreateDTO
            {
                Name = "Sorvete",
                Brand = "Nestlé",
                Weight = 200
            };

            var productEntity = new Product(productCreate.Name, productCreate.Brand, productCreate.Weight);

            _productRepositoryMock
                .Setup(r => r.CheckingExistingProductAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync((Product)null!);

            _productRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Product>()))
                .ReturnsAsync(productEntity);

            var result = await _productService.CreateAsync(productCreate);

            Assert.NotNull(result);
            Assert.Equal(productCreate.Name, result.Name);
            Assert.Equal(productCreate.Brand, result.Brand);
            Assert.Equal(productCreate.Weight, result.Weight);
        }


        [Fact]
        public async Task CreateProducts_ShoulReturnArgumentNullException()
        {
            ProductCreateDTO productCreateDTO = new()
            {
                Brand = Faker.Lorem.Sentence(),
                Weight = Faker.RandomNumber.Next(10),
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _productService.CreateAsync(productCreateDTO));

            Assert.Contains("Product name can't be null", ex.Message);
        }
        [Fact]
        public async Task CreateAsync_ShouldThrowConflictException_WhenProductAlreadyExists()
        {
            var productCreate = new ProductCreateDTO
            {
                Name = "Picolé",
                Brand = "Kibon",
                Weight = 100
            };

            _productRepositoryMock
               .Setup(r => r.CheckingExistingProductAsync(It.IsAny<Expression<Func<Product, bool>>>()))
               .ReturnsAsync(new Product("Picolé", "Kibon", 100));

            await Assert.ThrowsAsync<ConflictException>(
                () => _productService.CreateAsync(productCreate)
            );
        }
        #endregion

        #region Get
        [Fact]
        public async Task GetAsync_ShouldReturnNull_WhenProductDoesNotExist()
        {
            int productId = 1;

            _productRepositoryMock
                .Setup(r => r.GetAsync(productId))
                .ReturnsAsync((Product)null!);

            var result = await _productService.GetAsync(productId);

            Assert.Null(result);
            _productRepositoryMock.Verify(r => r.GetAsync(productId), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnProduct()
        {
            int productId = 1;
            var productEntity = new Product("Picolé", "Kibon", 100);

            _productRepositoryMock
                .Setup(r => r.GetAsync(productId))
                .ReturnsAsync(productEntity);

            var result = await _productService.GetAsync(productId);

            Assert.NotNull(result);
            Assert.Equal(productEntity.Name, result.Name);
            Assert.Equal(productEntity.Brand, result.Brand);
            Assert.Equal(productEntity.Weight, result.Weight);

            _productRepositoryMock.Verify(r => r.GetAsync(productId), Times.Once);
        }


        #endregion

        #region GetAll
        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfProduct()
        {
            var products = new List<Product>
            {
                new Product("Picolé", "Kibon", 100),
                new Product("Sorvete", "Nestlé", 200)
            };

            _productRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(products);

            var result = await _productService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count);

            for (int i = 0; i < products.Count; i++)
            {
                Assert.Equal(products[i].Name, result[i].Name);
                Assert.Equal(products[i].Brand, result[i].Brand);
                Assert.Equal(products[i].Weight, result[i].Weight);
            }

            _productRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        }


        #endregion

        #region Update

        [Fact]
        public async Task UpdateAsync_ShouldReturnProduct()
        {
            int productId = 1;
            var foundProduct = new Product("Picolé", "Kibon", 100);
            var updatedProduct = new ProductUpdateDTO
            {
                Name = "Sorvete",
                Brand = "Nestlé",
                Weight = 200
            };

            _productRepositoryMock
                .Setup(r => r.GetAsync(productId))
                .ReturnsAsync(foundProduct);

            _productRepositoryMock
                .Setup(r => r.UpdateAsync(productId, It.IsAny<Product>()))
                .ReturnsAsync(new Product(updatedProduct.Name, updatedProduct.Brand, updatedProduct.Weight));

            var result = await _productService.UpdateAsync(productId, updatedProduct);

            Assert.NotNull(result);
            Assert.Equal(updatedProduct.Name, result.Name);
            Assert.Equal(updatedProduct.Brand, result.Brand);
            Assert.Equal(updatedProduct.Weight, result.Weight);

            _productRepositoryMock.Verify(r => r.GetAsync(productId), Times.Once);
            _productRepositoryMock.Verify(r => r.UpdateAsync(productId, It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull_WhenProductNotFound()
        {
            int productId = 1;
            var updatedProduct = new ProductUpdateDTO
            {
                Name = "Sorvete",
                Brand = "Nestlé",
                Weight = 200
            };

            _productRepositoryMock
                .Setup(r => r.GetAsync(productId))
                .ReturnsAsync((Product)null!);

            var result = await _productService.UpdateAsync(productId, updatedProduct);

            Assert.Null(result);
            _productRepositoryMock.Verify(r => r.GetAsync(productId), Times.Once);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenProductNotFound()
        {
            int productId = 1;

            _productRepositoryMock
                .Setup(r => r.GetAsync(productId))
                .ReturnsAsync((Product)null!);

            var result = await _productService.DeleteAsync(productId);

            Assert.False(result);
            _productRepositoryMock.Verify(r => r.GetAsync(productId), Times.Once);
            _productRepositoryMock.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue()
        {
            int productId = 1;
            var foundProduct = new Product("Picolé", "Kibon", 100);

            _productRepositoryMock
                .Setup(r => r.GetAsync(productId))
                .ReturnsAsync(foundProduct);

            _productRepositoryMock
                .Setup(r => r.DeleteAsync(productId))
                .Returns(Task.CompletedTask);

            var result = await _productService.DeleteAsync(productId);

            Assert.True(result);
            _productRepositoryMock.Verify(r => r.GetAsync(productId), Times.Once);
            _productRepositoryMock.Verify(r => r.DeleteAsync(productId), Times.Once);
        }
        #endregion

    }
}
