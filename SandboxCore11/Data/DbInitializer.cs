namespace SandboxCore11.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

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

            var suppliers = new Supplier[]
            {
                new Supplier { Name = "Supplier 1" },
                new Supplier { Name = "Supplier 2" }
            };

            db.AddRange(suppliers);

            var purchaseOrders = new PurchaseOrder[]
            {
                new PurchaseOrder { Supplier = suppliers[0], Status = "Requested", RequestedDate = DateTime.Now.AddDays(-1) },
                new PurchaseOrder { Supplier = suppliers[0], Status = "Confirmed", RequestedDate = DateTime.Now.AddDays(-2), ConfirmedDate = DateTime.Now.AddDays(-2), ExpectedDeliveryDate = DateTime.Now.AddDays(1) },
                new PurchaseOrder { Supplier = suppliers[0], Status = "Received", RequestedDate = DateTime.Now.AddDays(-5), ConfirmedDate = DateTime.Now.AddDays(-4), ExpectedDeliveryDate = DateTime.Now.AddDays(-1), ReceivedDate = DateTime.Now.AddDays(-2) },
                new PurchaseOrder { Supplier = suppliers[0], Status = "Cancelled", RequestedDate = DateTime.Now.AddDays(-1) },
                new PurchaseOrder { Supplier = suppliers[0], Status = "Requested", RequestedDate = DateTime.Now.AddDays(0) },
                new PurchaseOrder { Supplier = suppliers[0], Status = "Confirmed", RequestedDate = DateTime.Now.AddDays(-4), ConfirmedDate = DateTime.Now.AddDays(-2), ExpectedDeliveryDate = DateTime.Now.AddDays(5) }
            };

            db.AddRange(purchaseOrders);
        }

        private static void TearDown(ApplicationDbContext db)
        {
            db.RemoveRange(db.Brands);
            db.RemoveRange(db.Categories);
            db.RemoveRange(db.InventoryItems);
        }
    }
}
