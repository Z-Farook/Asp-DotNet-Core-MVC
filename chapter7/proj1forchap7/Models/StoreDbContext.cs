using Microsoft.EntityFrameworkCore;
namespace proj1forchap7.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}