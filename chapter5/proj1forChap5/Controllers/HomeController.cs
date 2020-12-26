using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proj1forChap5.Models;
namespace proj1forChap5.Controllers
{
    public class HomeController : Controller
    {
        //utilizing the USING
        public ViewResult Index()
        {
            List<string> results = new List<string>();

            foreach (/*Our own model*/Item x in Item.GetItems())
            {
                // note string itself allows to be null so we don't use ? with it unlike the decimal
                string name = x?.Name ?? "Oops";
                decimal? price = x?.Price ?? 0;
                string relatedName = x?.Related?.Name ?? "Nothing related here!";
                // results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
                //or
                //:C2 would format the price value as a currency value with two decimal digits.
                results.Add($"Name: {name}, Price: {price:C2}, Related: {relatedName}");
            }
            return View(results);
            // return View(new string[] { "C#", "Language", "Features" });
        }
#if false //won't run this block 
//Object and Collection Initializers
            Dictionary<string, Item> products = new Dictionary<string, Item>
            {
             { "Kayak", new Item { Name = "Kayak", Price = 275M } },
             { "Lifejacket", new Item{ Name = "Lifejacket", Price = 48.95M } }
            };
            return View("Index", products.Keys);
#endif
#if false //won't run this block
//Using an Index Initializer
            Dictionary<string, Item> products = new Dictionary<string, Item> {
             ["Kayak"] = new Item { Name = "Kayak", Price = 275M },
             ["Lifejacket"] = new Item { Name = "Lifejacket", Price = 48.95M }
             };

#endif
        #region 
        // test this: http://localhost:5000/Home/ExtentionIndex
#if false
        public string ExtentionIndex()
        {
            ShoppingCart cart = new ShoppingCart { Items = Item.GetItems() };
            decimal cartTotal = cart.TotalPrices();
            return "$" + cartTotal.ToString() ?? "0";
        }
#endif

        #endregion
        #region using the IEnumerable<Item>  interface 
#if false
        // test this: http://localhost:5000/Home/ExtentionIndex
        public string ExtentionIndex()
        {
            //   return $"Cart";
            ShoppingCart cart = new ShoppingCart { Items = Item.GetItems() };
            Item[] productArray = {
                new Item {Name = "Kayak", Price = 275M},
                new Item {Name = "Lifejacket", Price = 48.95M},
                new Item {Name = "Soccer ball", Price = 19.50M},
                new Item {Name = "Corner flag", Price = 34.95M}
            };

            decimal cartTotal = cart.TotalPrices();

            decimal arrayTotal = productArray.TotalPrices();
            decimal arrayTotalFiltered = productArray.FilterByPrice(20).TotalPrices();

            return $"Cart Total: { cartTotal:C2} \nArray Total: {arrayTotal:C2} \nFiltered Array Total: {arrayTotalFiltered:C2}";
        }
#endif
        #endregion

        #region lambda region 
        public string ExtentionIndex()
        {
            //   return $"Cart";
            ShoppingCart cart = new ShoppingCart { Items = Item.GetItems() };
            Item[] productArray = {
                new Item {Name = "Kayak", Price = 275M},
                new Item {Name = "Lifejacket", Price = 48.95M},
                new Item {Name = "Soccer ball", Price = 19.50M},
                new Item {Name = "Corner flag", Price = 34.95M}
            };
#if false // this still bit long work around
            bool FilterByPrice(Item i)
            {
                return (i?.Price ?? 0) >= 20;
            }
            Func<Item, bool> nameFilter = delegate (Item prod)
            {
                return prod?.Name?[0] == 'S';
            };
            decimal priceFilterTotal = productArray.LambdaFilter(FilterByPrice).TotalPrices();
            decimal nameFilterTotal = productArray.LambdaFilter(nameFilter).TotalPrices();
#endif
            //more elegant 
            decimal priceFilterTotal = productArray.LambdaFilter(p => (p?.Price ?? 0) >= 100).TotalPrices();
            decimal nameFilterTotal = productArray.LambdaFilter(p => p?.Name?[0] == 'S').TotalPrices();
            return $"Price Filter Total: { priceFilterTotal:C2} \nName Filter Total: {nameFilterTotal:C2}";
            #endregion
        }
    }
}

