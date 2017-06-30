namespace SandboxCore11.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class InventoryItemNameExistsQueryHandler : IQueryHandlerAsync<InventoryItemNameExistsQuery, bool>
    {
        private ApplicationDbContext db;

        public InventoryItemNameExistsQueryHandler(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> HandleAsync(InventoryItemNameExistsQuery query)
        {
            var count = await db.InventoryItems.CountAsync(x => x.Name == query.Name);

            return count > 0;
        }
    }
}
