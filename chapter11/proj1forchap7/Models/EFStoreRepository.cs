using System.Linq;
namespace proj1forchap7.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        /* implimenting the interface here!!!
        * and the context.Products is POINTING to the StoreDbContext.Products*/
        public IQueryable<Product> Products => context.Products;

        public void CreateProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            context.Remove(p);
            context.SaveChanges();

        }

        public void SaveProduct(Product p)
        {
            context.SaveChanges();
        }
    }
}