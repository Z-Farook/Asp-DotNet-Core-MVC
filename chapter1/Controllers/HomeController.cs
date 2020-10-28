using Microsoft.AspNetCore.Mvc;

namespace chapter1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = System.DateTime.Now.Hour;
            string viewModel = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView", viewModel);
        }

    }
}
