using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proj1forChap5.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace proj1forChap5.Controllers
{
    public class GettingNameController : Controller
    {
        // test at: http://localhost:5000/GettingName/index
        public string Index()
        {
            var products = new[] {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
        };
            var resQuery = products.Select(p => p.Price);
            var res = "";
            foreach (var item in resQuery)
            {
                res += "Price: " + item + "\n";
            }

            return res;
        }
        public ViewResult IndexTwo()
        {
            var products = new[] {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
        };
            // return View(products.Select(p => $"Name: {p.Name}, Price: {p.Price}"));
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }

    }
}