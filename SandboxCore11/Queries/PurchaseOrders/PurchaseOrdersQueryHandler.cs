namespace SandboxCore11.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class PurchaseOrdersQueryHandler : IQueryHandlerAsync<PurchaseOrdersQuery, List<PurchaseOrder>>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public PurchaseOrdersQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<PurchaseOrder>> HandleAsync(PurchaseOrdersQuery query)
        {
            var data = await db.PurchaseOrders.Include(x => x.Supplier).ToListAsync();
            var orders = mapper.Map<List<PurchaseOrder>>(data);
            return orders;
        }
    }
}
