using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proj1forchap7.Infrastructure;
using proj1forchap7.Models;
using System.Linq;

namespace proj1forchap7.Pages
{

    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo)
        {
            repository = repo;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        #region handler methods
        /* The handler methods use parameter names that match the input elements in the HTML forms produced by the ProductSummary.cshtml view. */
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        #endregion
    }
}
