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
    public class CartTest
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            //Given
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };
            Cart target = new Cart();
            //When
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] res = target.Lines.ToArray();
            //Then
            Assert.Equal(2, res.Length);
        }
        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            target.AddItem(p1, 1);
            CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();
            // Assert
            Assert.Equal(2, results.Length);
            /* check that if the same object is order more than one then its quantity is raised not the class instance  */
            Assert.Equal(12, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }
        [Fact]
        public void Can_Remove_Line()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);
            // Act
            target.RemoveLine(p2);
            // Assert
            Assert.Empty(target.Lines.Where(c => c.Product == p2));
            Assert.True(target.Lines[0].Product.Name == "P1");
            Assert.True(target.Lines[1].Product.Name != "P2");
            Assert.Equal(2, target.Lines.Count());
        }
        [Fact]
        public void Calculate_Cart_Total()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();
            // Assert
            Assert.Equal(450M, result);
        }
        [Fact]
        public void Can_Clear_Contents()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };
            // Arrange - create a new cart
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            // Act - reset the cart
            target.Clear();
            // Assert
            Assert.Empty(target.Lines);
        }
    }
}