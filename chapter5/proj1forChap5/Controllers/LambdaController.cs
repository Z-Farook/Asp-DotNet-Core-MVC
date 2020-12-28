using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proj1forChap5.Models;
using System.Linq;
namespace proj1forChap5.Controllers
{
    public class LambdaController : Controller
    {
        private object Implimentation;
        #region Lambda Expression Methods and Properties

#if false // the book vode not worked for simple string return
public ViewResult Index() =>
 View(Product.GetProducts().Select(p => p?.Name));
#endif
        // test using: http://localhost:5000/Lambda/Index
        public string Index()
        {
            IEnumerable<Item> query = from itemX in Item.GetItems()
                                      where itemX?.Price > 20
                                      select itemX;
            var res = "";
            foreach (var item in query)
            {
                res += "Price: " + item.Price + "\n";
            }
            return res;
        }
        #endregion


        #region Default Implementations in Interfaces
        // test uing: http://localhost:5000/Lambda/IndexWithInterface
        public string IndexWithInterface()
        {
            IItemSelection cart = new ShoppingCart(
            new Item { Name = "Kayak", Price = 275M },
            new Item { Name = "Lifejacket", Price = 48.95M },
            new Item { Name = "Soccer ball", Price = 19.50M },
            new Item { Name = "Corner flag", Price = 34.95M }
            );
            var res = "";
            foreach (var item in cart.Products)
            {
                res += "Name: " + item.Name + "\n";
            }

            var resOfDefaultPropImplimentation = "\n";
            foreach (var item in cart.Names)
            {
                resOfDefaultPropImplimentation += $"Default prop result: {item} \n";
            }
            return res + resOfDefaultPropImplimentation;
        }
        #endregion
    }
}