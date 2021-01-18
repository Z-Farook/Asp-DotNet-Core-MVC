using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using proj1forchap7.Controllers;
using proj1forchap7.Models;
using proj1forchap7.Models.ViewModels;
using Xunit;
using System;
namespace proj1forchap7_Test
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"}
                }).AsQueryable<Product>());

            /*creating a mock repository, injecting it into the
            constructor of the HomeController class */
            HomeController controller = new HomeController(mock.Object);

            // Act
            IEnumerable<Product> result = (controller.Index() as ViewResult)
            .ViewData.Model as IEnumerable<Product>;

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }

        [Fact]
        public void Can_Paginate()
        {
            //Arrange 
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(p => p.Products).Returns(
                (new Product[]{
                    new Product { ProductID = 1, Name = "P1" },
                    new Product { ProductID = 2, Name = "P2" },
                    new Product { ProductID = 3, Name = "P3" },
                    new Product { ProductID = 4, Name = "P4" },
                    new Product { ProductID = 5, Name = "P5" }
                }
            ).AsQueryable<Product>());

            var controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            // Act
            IEnumerable<Product> result = (controller.Index(2) as ViewResult).ViewData.Model as IEnumerable<Product>;
            /* What we get form Controller after calculation.? We have 5 fake Products in our IStoreRepository
            .Skip((productPage - 1) * PageSize) => ? 
            .Take(PageSize)) => ?*/

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            System.Console.WriteLine(prodArray.Length);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {

            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());

            // Arrange
            HomeController controller =
                new HomeController(mock.Object) { PageSize = 3 };

            // Act
            ProductsListViewModel result =
                controller.ProductsWithPagination(null, 2).ViewData.Model as ProductsListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
        [Fact]
        public void Can_Filter_Products()
        {
            //Given
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]{
                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
            }).AsQueryable<Product>());

            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            //When
            Product[] result = (controller.ProductsWithPagination("Cat2", 1).ViewData.Model as ProductsListViewModel).Products.ToArray();

            //Then
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");

        }
        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            //Given
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
                }).AsQueryable<Product>()
            );
            HomeController target = new HomeController(mock.Object);
            target.PageSize = 3;
            Func<ViewResult, ProductsListViewModel> GetModel = vResult => vResult?.ViewData?.Model as ProductsListViewModel;
            //When
            int? res1 = GetModel(target.ProductsWithPagination("Cat1"))?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.ProductsWithPagination("Cat2"))?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.ProductsWithPagination("Cat3"))?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.ProductsWithPagination(null))?.PagingInfo.TotalItems;
            //Then
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);

        }
    }
}