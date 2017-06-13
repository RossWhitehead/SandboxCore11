using Microsoft.EntityFrameworkCore;
using SandboxCore11.Data;
using System.Collections.Generic;

namespace SandboxCore11.Tests.Builders
{
    public class ApplicationDbContextBuilder
    {
        private ApplicationDbContext applicationDbContext;
        private List<InventoryItem> inventoryItems;

        public ApplicationDbContextBuilder()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "write")
               .Options;

            this.applicationDbContext = new ApplicationDbContext(options);
        }

        public ApplicationDbContext Build()
        {
            this.applicationDbContext.InventoryItems.AddRange(this.inventoryItems);
            this.applicationDbContext.SaveChanges();
            return this.applicationDbContext;
        }

        public ApplicationDbContextBuilder WithInventoryItems(List<InventoryItem> inventoryItems)
        {
            this.inventoryItems = inventoryItems;
            return this;
        }

        public static implicit operator ApplicationDbContext(ApplicationDbContextBuilder instance)
        {
            return instance.Build();
        }
    }
}
