using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RevatrueP1.Models;

namespace RevatrueP1.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StoreContext>>()))
            {

                if (context.Products.Any() || context.Stores.Any())
                {
                    return; 
                }

                context.Stores.AddRange(
                    new Store
                    {
                        City = "Seattle"
                    },
                    new Store
                    {
                        City = "Denver",
                    },
                    new Store
                    {
                        City = "San Antonio"
                    }
                );

                context.SaveChanges();

                context.Products.AddRange(
                    new Product
                    {
                        ProductName = "Eggs",
                        StoreID = 1,
                        Quantity = 50,
                        Price = 5.00M
                    },
                    new Product
                    {
                        ProductName = "Cabbage",
                        StoreID = 1,
                        Quantity = 10,
                        Price = 3.00M
                    },
                    new Product
                    {
                        ProductName = "Orange Juice",
                        StoreID = 1,
                        Quantity = 40,
                        Price = 4.00M
                    },
                    new Product
                    {
                        ProductName = "Chips",
                        StoreID = 2,
                        Quantity = 60,
                        Price = 6.00M
                    },
                    new Product
                    {
                        ProductName = "Eggs",
                        StoreID = 2,
                        Quantity = 40,
                        Price = 4.00M
                    },
                    new Product
                    {
                        ProductName = "Spinich",
                        StoreID = 2,
                        Quantity = 20,
                        Price = 3.00M
                    },
                    new Product
                    {
                        ProductName = "Green Pepper",
                        StoreID = 3,
                        Quantity = 30,
                        Price = 2.00M
                    },
                    new Product
                    {
                        ProductName = "Kale",
                        StoreID = 3,
                        Quantity = 50,
                        Price = 3.00M
                    },
                    new Product
                    {
                        ProductName = "Pork",
                        StoreID = 3,
                        Quantity = 50,
                        Price = 8.00M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
