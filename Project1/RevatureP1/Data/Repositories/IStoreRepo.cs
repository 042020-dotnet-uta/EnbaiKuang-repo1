using RevatrueP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureP1.Data.Repositories
{
    public interface IStoreRepo
    {
        public IQueryable<Store> getStores();
        public Task<IEnumerable<Order>> getStoreHistory(int id);
    }
}
