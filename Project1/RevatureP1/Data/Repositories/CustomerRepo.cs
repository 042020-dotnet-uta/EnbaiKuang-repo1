using RevatrueP1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevatureP1.Data.Repositories;
using System;

namespace RevatrueP1.Data.Repositories
{
     public class CustomerRepo : ICustomerRepo
    {
        private readonly StoreContext _context;

        public CustomerRepo(StoreContext context) {
            _context = context;
        }
        // use to return all users in the database
        public IQueryable<User> getUsers()
        {
            return _context.Customers;
        }
        // search database by users first name
        public IQueryable<User> firstNameSearch(string name)
        {
            return _context.Customers.Where(s => s.FirstName.Contains(name));
        }
        // search database by user last name
        public IQueryable<User> lastNameSearch(string name)
        {
            return _context.Customers.Where(s => s.LastName.Contains(name));
        }

        // used to get the order history of a customer, needs to be debugged
        // issue with not recognizing tolistasync
        public async Task<IEnumerable<Order>> getCustomerHistory(int id)
        {
            return await _context.Orders
            .Where(o => o.User.UserID == id)
            .Include(o => o.User)
            .Include(o => o.Product)
            .ThenInclude(p => p.Store)
            .OrderBy(o => o.Timestamp)
            .ToListAsync();
        }
    }
}
