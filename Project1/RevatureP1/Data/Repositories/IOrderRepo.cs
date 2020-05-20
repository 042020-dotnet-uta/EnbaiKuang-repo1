using RevatrueP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureP1.Data.Repositories
{
    public interface IOrderRepo
    {
        public IQueryable<Order> getOrders();
        public Task<Order> orderDetails(int id);
    }
}
