using System.Linq;
namespace proj1forchap7.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Order { get; }
        void SaveOrder(Order order);


    }
}