using Microsoft.AspNetCore.Mvc;
using proj1forchap7.Models;
namespace proj1forchap7.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index() => View(repository.Products);
    }
}