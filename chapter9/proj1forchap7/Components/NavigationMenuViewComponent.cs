using Microsoft.AspNetCore.Mvc;
using System.Linq;
using proj1forchap7.Models;
namespace proj1forchap7.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        /// <summary>
        /// The view component’s Invoke method is called when the component is used in a Razor view, and the result of the Invoke
        /// method is inserted into the HTML sent to the browser
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            /* dynamically assigned a SelectedCategory property to the ViewBag object and set its value to
                be the current category */
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}