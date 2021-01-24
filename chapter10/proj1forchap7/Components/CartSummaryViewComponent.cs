using Microsoft.AspNetCore.Mvc;
using proj1forchap7.Models;
namespace proj1forchap7.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartservice)
        {
            cart = cartservice;
        }

        /// <summary>The view component’s INVOKE METHOD IS CALLED WHEN THE COMPONENT IS USED IN A RAZOR VIEW, and the result of the Invoke
        /// method is inserted into the HTML sent to the browser
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }

}