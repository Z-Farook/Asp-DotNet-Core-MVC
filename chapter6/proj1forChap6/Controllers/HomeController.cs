
using Microsoft.AspNetCore.Mvc;
using proj1forChap6.Models;
namespace proj1forChap6.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(Product.GetProducts());
        }
    }
}