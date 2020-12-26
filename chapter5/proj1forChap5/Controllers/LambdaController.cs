using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proj1forChap5.Models;
using System.Linq;
namespace proj1forChap5.Controllers
{
    public class LambdaController : Controller
    {
        #region Lambda Expression Methods and Properties
#if false
public ViewResult Index() =>
 View(Product.GetProducts().Select(p => p?.Name));
#endif
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
    }
}