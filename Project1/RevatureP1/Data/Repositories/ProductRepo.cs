using Microsoft.EntityFrameworkCore;
using RevatrueP1.Models;
using RevatureP1.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatrueP1.Data.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _context;

        public ProductRepo(StoreContext context) {
            _context = context;
        }
        public IQueryable<Product> getProducts()
        {
            return _context.Products;
        }

        // returns the stock of a product in a store inventory
        public int getQuantity(int id)
        {
            return _context.Products
                .Where(p => p.ProductID == id)
                .Select(p => p.Quantity)
                .SingleOrDefault();
        }
        // decrement store stock according to order quantity, amount check should
        //be done before this using business logic
        public void updateStock(int id, int quantity)
        {
            var product = _context.Products
                .Where(p => p.ProductID == id)
                .FirstOrDefault();
            product.Quantity -= quantity;
            _context.SaveChanges();
        }

        // gets list of all products
        public async Task<IEnumerable<Product>> getProductList()
        {
            return await _context.Products
                .Include(p => p.Store)
                .OrderBy(p => p.Store.StoreID)
                .ToListAsync();
        }
    }
}
