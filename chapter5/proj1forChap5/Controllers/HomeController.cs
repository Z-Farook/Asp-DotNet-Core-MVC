using Microsoft.AspNetCore.Mvc;
namespace proj1forChap5.Controllers
{
    public class HomeController : Controller
    {
        //utilizing the USING
        public ViewResult Index()
        {
            return View(new string[] { "C#", "Language", "Features" });
        }
    }
}