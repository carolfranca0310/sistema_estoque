using InventoryManagement.Domain.DTO;
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

        [Fact]
        public async Task CreateProducts_ShoulReturnArgumentNullException()
        {
            ProductCreateDTO productCreateDTO = new()
            {
                Brand = Faker.Lorem.Sentence(),
                Weight = Faker.RandomNumber.Next(10),
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _productService.CreateAsync(productCreateDTO)) ;

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
               .ReturnsAsync(new Product("Picolé","Kibon", 100));

            await Assert.ThrowsAsync<ConflictException>(
                () => _productService.CreateAsync(productCreate)
            );
        }
    }
}
