using Microsoft.AspNetCore.Mvc;
using proj1forchap7.Models;
using System.Linq;
namespace proj1forchap7.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        // public IActionResult Index() => View(repository.Products);

        // adding Pagination
        public ViewResult Index(int productPage = 1)
         => View(repository.Products
         .OrderBy(p => p.ProductID)
         .Skip((productPage - 1) * PageSize)
         .Take(PageSize));
    }
}