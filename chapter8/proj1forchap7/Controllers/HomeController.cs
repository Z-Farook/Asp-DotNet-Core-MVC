using Microsoft.AspNetCore.Mvc;
using proj1forchap7.Models;
using System.Linq;
using proj1forchap7.Models.ViewModels;
namespace proj1forchap7.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        // public IActionResult Index() => View(repository.Products);

        // adding Pagination
        public ViewResult Index(int productPage = 1)
         => View(repository.Products
         .OrderBy(p => p.ProductID)
         .Skip((productPage - 1) * PageSize)
         .Take(PageSize));
        public ViewResult ProductsWithPagination(string category, int productPage = 1) => View(new ProductsListViewModel
        {
            //setting the 1st prop of ProductsListViewModel.Products
            Products = repository.Products.Where(p => category == null || p.Category == category)
                         .OrderBy(p => p.ProductID)
                         .Skip((productPage - 1) * PageSize)
                         .Take(PageSize),
            ////setting the 2nd prop of ProductsListViewModel.PagingInfo
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        });
    }
}