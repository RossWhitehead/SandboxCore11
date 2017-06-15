using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore11.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                TearDown(db);
                Setup(db);
                await db.SaveChangesAsync();
            }
        }

        private static void Setup(ApplicationDbContext db)
        {
            var brands = new Brand[]
                {
                    new Brand() { Name = "Cannondale" },
                    new Brand() { Name = "Giant" }
                };

            db.AddRange(brands);

            var categories = new Category[]
                {
                    new Category() { Name = "Road bikes" },
                    new Category() { Name = "Mountain bikes" }
                };

            db.AddRange(categories);

            var inventoryItems = new InventoryItem[]
                {
                    new InventoryItem { Brand = brands[0], Category = categories[0], Description = "Item 1 description", ReorderLevel = 100, ReorderQuantity = 20, Name = "Item 1" },
                    new InventoryItem { Brand = brands[0], Category = categories[0], Description = "Item 2 description", ReorderLevel = 100, ReorderQuantity = 20, Name = "Item 2" },
                    new InventoryItem { Brand = brands[1], Category = categories[1], Description = "Item 3 description", ReorderLevel = 100, ReorderQuantity = 20, Name = "Item 3" }
                };

            db.AddRange(inventoryItems);
        }

        private static void TearDown(ApplicationDbContext db)
        {
            db.RemoveRange(db.Brands);
            db.RemoveRange(db.Categories);
            db.RemoveRange(db.InventoryItems);
        }
    }
}
