using RevatrueP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureP1.Data.Repositories
{
    public interface IProductRepo
    {
        public IQueryable<Product> getProducts();
        public int getQuantity(int id);
        public void updateStock(int id, int quant);
        public Task<IEnumerable<Product>> getProductList();
    }
}
