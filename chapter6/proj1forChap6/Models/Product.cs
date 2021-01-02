using System.Collections.Generic;
namespace proj1forChap6.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M
            };
            Product lifejacket = new Product
            {
                Name = "Lifejacket",
                Price = 48.95M
            };
            return new Product[] { kayak, lifejacket };
        }
    }
    public class ProductDataSource : IDataSource
    {
        // the interface method implimentation
        public IEnumerable<Product> Products =>
            new Product[] {
                    new Product { Name = "Kayak", Price = 275M },
                    new Product { Name = "Lifejacket", Price = 48.95M }
            };
    }
}