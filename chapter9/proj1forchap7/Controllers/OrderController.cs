using System.Linq;
using Microsoft.AspNetCore.Mvc;
using proj1forchap7.Models;
using myModels = proj1forchap7.Models;
namespace proj1forchap7.Controllers
{
    public class OrderController : Controller
    {
        private myModels.IOrderRepository _repository;
        private myModels.Cart _cart;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("orderError", "Sorry your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();

                _repository.SaveOrder(order);

                _cart.Clear();

                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }
    }
}