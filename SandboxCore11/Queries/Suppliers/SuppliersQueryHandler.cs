namespace SandboxCore11.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class SuppliersQueryHandler : IQueryHandlerAsync<SuppliersQuery, List<Supplier>>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public SuppliersQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<Supplier>> HandleAsync(SuppliersQuery query)
        {
            var data = await db.Suppliers.ToListAsync();
            var suppliers = mapper.Map<List<Supplier>>(data);
            return suppliers;
        }
    }
}
