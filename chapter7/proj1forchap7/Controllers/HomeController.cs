using Microsoft.AspNetCore.Mvc;
namespace proj1forchap7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}