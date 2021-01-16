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