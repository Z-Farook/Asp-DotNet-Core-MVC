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
                results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
                results.Add(string.Format("Name: {0}, Price: {1}", name, price));
            }
            return View(results);
            // return View(new string[] { "C#", "Language", "Features" });
        }
    }
}