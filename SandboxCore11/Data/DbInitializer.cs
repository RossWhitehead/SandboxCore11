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
            var inventoryItems = new InventoryItem[]
           {
                new InventoryItem { Name = "Item 1" },
                new InventoryItem { Name = "Item 2" },
                new InventoryItem { Name = "Item 3" }
           };

            db.AddRange(inventoryItems);
        }

        private static void TearDown(ApplicationDbContext db)
        {
            db.RemoveRange(db.InventoryItems);
        }
    }
}
