
using FakeItEasy;
using NUnit.Framework;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.Services;

namespace WebshopUnitTest.Services
{
    public class ProductServiceTests
    {
        private ProductRepository productRepository;
        private ProductService productService;
        
        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake<ProductRepository>();
            this.productService = new ProductService(this.productRepository);
        }
        
        [Test]
        public void Get_GivenId_ReturnsResultFromRepository()
        {
            // Arrange
            const int Id = 13;
            var item = new Products
            {
                Id = Id,
                Name = "Hendricks Gin",
                Price = 449
            };

            A.CallTo(() => this.productRepository.Get(Id)).Returns(item);

            // Act
            var result = this.productService.Get(Id);

            // Assert
            Assert.That(result, Is.EqualTo(item));
        }
    }
}