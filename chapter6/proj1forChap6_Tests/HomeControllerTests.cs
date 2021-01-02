using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proj1forChap6.Controllers;
using proj1forChap6.Models;
using Xunit;
namespace proj1forChap6.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            var controller = new HomeController();
            Product[] products = new Product[] {
                    new Product { Name = "Kayak", Price = 275M },
                    new Product { Name = "Lifejacket", Price = 48.95M}
                };
            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Assert
            Assert.Equal(products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
        //isolated controller test
        class FakeDataSource : IDataSource
        {
            public IEnumerable<Product> Products { get; set; }
            public FakeDataSource(Product[] data) => Products = data;
        }

        [Fact]
        public void IndexActionModelIsComplete2()
        {
            // Arrange
            Product[] testData = new Product[] {
                    new Product { Name = "P1", Price = 75.10M },
                    new Product { Name = "P2", Price = 120M },
                    new Product { Name = "P3", Price = 110M }
                };

            IDataSource data = new FakeDataSource(testData);
            var controller = new HomeController();
            controller.dataSource = data;

            // Act
            var model = (controller.Index2() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(data.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}