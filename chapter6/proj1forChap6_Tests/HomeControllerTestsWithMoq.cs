using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proj1forChap6.Controllers;
using proj1forChap6.Models;
using Xunit;
using Moq;
namespace proj1forChap6.Tests
{
    public class HomeControllerTestsWithMoq
    {
        /*fake implementation of the IDataSource interface. Not needed anymore*/
        //class FakeDataSource : IDataSource {
        // public FakeDataSource(params Product[] data) => Products = data;
        // public IEnumerable<Product> Products { get; set; }
        //}
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            Product[] testData = new Product[] {
                    new Product { Name = "P1", Price = 75.10M },
                    new Product { Name = "P2", Price = 120M },
                    new Product { Name = "P3", Price = 110M }
                };

            var mock = new Mock<IDataSource>();

            mock.SetupGet(m => m.Products).Returns(testData);

            var controller = new HomeController();

            controller.dataSource = mock.Object;

            // Act
            var model = (controller.Index2() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(testData, model, Comparer.Get<Product>((p1, p2) =>
                p1.Name == p2.Name && p1.Price == p2.Price));

            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}