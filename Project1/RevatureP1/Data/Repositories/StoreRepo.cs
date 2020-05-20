using RevatrueP1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevatureP1.Data.Repositories;

namespace RevatrueP1.Data.Repositories
{
    public class StoreRepo : IStoreRepo
    {
        private readonly StoreContext _context;

        public StoreRepo(StoreContext context) {
            _context = context;
        }
        //returns all stores in the database
        public IQueryable<Store> getStores()
        {
            return _context.Stores;
        }
        // suppose to return order history of a store, needs to be debugged.
        public async Task<IEnumerable<Order>> getStoreHistory(int id)
        {
            return await _context.Orders
                .Where(o => o.StoreID == id)
                .Include(o => o.User)
                .Include(o => o.Product)
                .OrderBy(o => o.Timestamp)
                .ToListAsync();
        }
    }
}
