using System.Collections.Generic;
using System.Linq;
namespace proj1forchap7.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(Product product, int quantity)
        {
            CartLine line = Lines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            Lines.RemoveAll(lines => lines.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue() => Lines.Sum(cartLine => cartLine.Product.Price * cartLine.Quantity);
        public void Clear() => Lines.Clear();

    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}