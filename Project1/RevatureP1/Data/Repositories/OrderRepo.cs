using RevatrueP1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevatureP1.Data.Repositories;

namespace RevatrueP1.Data.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly StoreContext _context;

        public OrderRepo(StoreContext context) {
            _context = context;
        }

        // returns all orders placed
        public IQueryable<Order> getOrders()
        {
            return _context.Orders;
        }

        // used to get all orders made by a specific customer
        public async Task<Order> orderDetails(int id)
        {
            return await _context.Orders
                .Where(o => o.OrderID == id)
                .Include(o => o.User)
                .Include(o => o.Product)
                .FirstOrDefaultAsync();
        }
    }
}
