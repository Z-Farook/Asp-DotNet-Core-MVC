using Microsoft.AspNetCore.Mvc;
using myModels = proj1forchap7.Models;
namespace proj1forchap7.c
{
    public class OrderController : Controller
    {
        public ViewResult Checkout()
        {
            return View(new myModels.Order());
        }
    }
}