using System.Linq;
namespace proj1forchap7.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}