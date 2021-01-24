using Microsoft.EntityFrameworkCore;
namespace proj1forchap7.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }
        // see te reference and the description of DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}