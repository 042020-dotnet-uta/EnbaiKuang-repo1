using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevatrueP1.Business_Logic;
using RevatrueP1.Data;
using RevatrueP1.Data.Repositories;
using RevatrueP1.Models;

namespace RevatrueP1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StoreContext _context;

        public OrdersController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var storeAppContext = _context.Orders.Include(o => o.User).Include(o => o.Product);
            return View(await storeAppContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo = new OrderRepo(_context);            
            var order = await repo.orderDetails((int)id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Customers, "OrderID");
            ViewData["ProductID"] = new SelectList(_context.Products, "OrderID", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,ProductID,UserID,Quantity,Timestamp")] Order order)
        {
            var check = new checkStock();
            var products = new ProductRepo(_context);
            
            if (ModelState.IsValid && check.checkStoreInventory(products.getQuantity(order.ProductID), order.Quantity))
            {
                products.updateStock(order.ProductID, order.Quantity);
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Customers, "OrderID", order.UserID.ToString());
            ViewData["ProductID"] = new SelectList(_context.Products, "OrderID", "ProductName", order.ProductID);
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Customers, "OrderID", "OrderID", order.UserID);
            ViewData["ProductID"] = new SelectList(_context.Products, "OrderID", "OrderID", order.ProductID);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,ProductID,UserID,Quantity,Timestamp")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Customers, "OrderID", "OrderID", order.UserID);
            ViewData["ProductID"] = new SelectList(_context.Products, "OrderID", "OrderID", order.ProductID);
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
