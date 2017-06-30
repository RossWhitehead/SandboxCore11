namespace SandboxCore11.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class InventoryItemQueryHandler : IQueryHandlerAsync<InventoryItemQuery, InventoryItem>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public InventoryItemQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<InventoryItem> HandleAsync(InventoryItemQuery query)
        {
            var data = await db.InventoryItems.Include(x => x.Brand).Include(x => x.Category).SingleAsync(m => m.InventoryItemId == query.InventoryItemId);
            var inventoryItem = mapper.Map<InventoryItem>(data);

            return inventoryItem;
        }
    }
}
