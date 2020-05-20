using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevatrueP1.Data;
using RevatrueP1.Data.Repositories;
using RevatrueP1.Models;

namespace RevatrueP1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly StoreContext _context;

        public CustomersController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string firstName, string lastName, string userName)
        {
            var customers = from c in _context.Customers
                            select c;

            if (!String.IsNullOrEmpty(firstName))
            {
                customers = customers.Where(s => s.FirstName.Contains(firstName));
            }
            if (!String.IsNullOrEmpty(lastName))
            {
                customers = customers.Where(s => s.FirstName.Contains(lastName));
            }
            if (!String.IsNullOrEmpty(userName))
            {
                customers = customers.Where(s => s.FirstName.Contains(userName));
            }

            return View(await customers.ToListAsync());
        }

        public async Task<IActionResult> Search(string firstName, string lastName, string userName)
        {
            var query = new CustomerRepo(_context);
            var customers = query.getUsers();

            if (!String.IsNullOrEmpty(firstName))
            {
                customers = query.firstNameSearch(firstName);
            }
            if (!String.IsNullOrEmpty(lastName))
            {
                customers = query.lastNameSearch(lastName);
            }

            return View(await customers.ToListAsync());
        }

        public async Task<IActionResult> History(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo = new CustomerRepo(_context);
            var customerHistory = await repo.getCustomerHistory((int)id);

            return View(customerHistory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,FirstName,LastName")] User customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,FirstName,LastName")] User customer)
        {
            if (id != customer.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.UserID))
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
            return View(customer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.UserID == id);
        }
    }
}
