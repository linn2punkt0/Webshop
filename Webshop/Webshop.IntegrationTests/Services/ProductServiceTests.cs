using Webshop.Repositories;
using Webshop.Services;
using NUnit.Framework;

namespace Webshop.IntegrationTests.Services
{
    public class ProductServiceTests
    {
        private ProductService productService;
            
        [SetUp]
        
        public void SetUp()
        {
            this.productService = new ProductService(
                new ProductRepository("Server=localhost;Database=Webshop;Uid=root;"
                ));
        }
        
        [Test]
        public void Get_GivenId_ReturnsResultFromDatabase()
        {
            // Act
            var results = this.productService.Get(13);

            // Assert
            Assert.That(results.Id, Is.EqualTo(13));
            Assert.That(results.Name, Is.EqualTo("Hendricks Gin"));
            Assert.That(results.Price, Is.EqualTo(449));
        }
    }
}