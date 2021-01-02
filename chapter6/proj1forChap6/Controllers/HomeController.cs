
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
        public IDataSource dataSource = new ProductDataSource();
        public ViewResult Index2()
        {
            return View(dataSource.Products);
        }
    }
}