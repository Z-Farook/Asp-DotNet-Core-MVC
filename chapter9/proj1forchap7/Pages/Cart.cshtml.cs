using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proj1forchap7.Infrastructure;
using proj1forchap7.Models;
using System.Linq;

namespace proj1forchap7.Pages
{

    public class CartModel : PageModel
    {
        public CartModel(IStoreRepository repoService, Cart cartServie)
        {
            repository = repoService;
            Cart = cartServie;
        }
        private IStoreRepository repository;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        #region handler methods
        /* The handler methods use parameter names that match the input elements in the HTML forms produced by the ProductSummary.cshtml view. */
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        #endregion

        #region handler methods to Remove X from the Cart
        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        #endregion
    }
}
