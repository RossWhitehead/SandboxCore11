namespace SandboxCore11.Queries
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class PurchaseOrderQueryHandler : IQueryHandlerAsync<PurchaseOrderQuery, PurchaseOrder>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public PurchaseOrderQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<PurchaseOrder> HandleAsync(PurchaseOrderQuery query)
        {
            var data = await db.PurchaseOrders.FirstOrDefaultAsync(x => x.PurchaseOrderId == query.Id);
            var order = mapper.Map<PurchaseOrder>(data);
            return order;
        }
    }
}
