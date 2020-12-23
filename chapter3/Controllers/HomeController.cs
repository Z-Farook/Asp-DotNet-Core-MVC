using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

// getting the model in
using chapter3.Models;
namespace chapter3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // return View(); == the next line
            return View("Views/Home/Index.cshtml");
        }
        [HttpGet]
        public ViewResult ReservationForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ReservationForm(GuestResponse guestResponse)
        {
            // TODO: store response from guest
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }
        public ViewResult ListResponses()
        {
            //passing the view model to the view method 
            return View(Repository.Responses.Where(r => r.Comming == true));
        }
    }
}
