namespace SandboxCore11.Tests.Builders
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;

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

        public static implicit operator ApplicationDbContext(ApplicationDbContextBuilder instance)
        {
            return instance.Build();
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
    }
}
