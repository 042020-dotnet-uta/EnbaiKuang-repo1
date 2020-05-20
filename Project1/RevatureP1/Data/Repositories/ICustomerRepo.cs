using RevatrueP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureP1.Data.Repositories
{
    public interface ICustomerRepo
    {
        public IQueryable<User> getUsers();
        public IQueryable<User> firstNameSearch(string name);
        public IQueryable<User> lastNameSearch(string name);
        public Task<IEnumerable<Order>> getCustomerHistory(int id);
    }
}
