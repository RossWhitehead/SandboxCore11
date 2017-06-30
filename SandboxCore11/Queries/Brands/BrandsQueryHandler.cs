namespace SandboxCore11.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class BrandsQueryHandler : IQueryHandlerAsync<BrandsQuery, List<Brand>>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public BrandsQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<Brand>> HandleAsync(BrandsQuery query)
        {
            var data = await db.Categories.ToListAsync();
            var brands = mapper.Map<List<Brand>>(data);
            return brands;
        }
    }
}
