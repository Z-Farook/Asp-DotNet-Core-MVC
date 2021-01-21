using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace proj1forchap7.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext _Context;
        public EFOrderRepository(StoreDbContext ctx)
        {
            _Context = ctx;
        }

        public IQueryable<Order> Order => _Context.Orders.Include(order => order.Lines)
            .ThenInclude(receivedLine => receivedLine.Product);

        public void SaveOrder(Order order)
        {
            _Context.AttachRange(order.Lines.Select(cartline => cartline.Product));
            if (order.OrderID == 0)
            {
                _Context.Orders.Add(order);

            }
            _Context.SaveChanges();
        }
    }

}