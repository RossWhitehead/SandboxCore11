namespace SandboxCore11.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class InventoryItemsQueryHandler : IQueryHandlerAsync<InventoryItemsQuery, List<InventoryItem>>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public InventoryItemsQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<InventoryItem>> HandleAsync(InventoryItemsQuery query)
        {
            var data = await db.InventoryItems.ToListAsync();
            var inventoryItems = mapper.Map<List<InventoryItem>>(data);
            return inventoryItems;
        }
    }
}
