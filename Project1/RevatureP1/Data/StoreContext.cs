using Microsoft.EntityFrameworkCore;
using RevatrueP1.Models;

namespace RevatrueP1.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext (DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<User> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
