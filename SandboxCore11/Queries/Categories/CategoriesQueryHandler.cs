namespace SandboxCore11.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Query;

    public class CategoriesQueryHandler : IQueryHandlerAsync<CategoriesQuery, List<Category>>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public CategoriesQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<Category>> HandleAsync(CategoriesQuery query)
        {
            var data = await db.Categories.ToListAsync();
            var categories = mapper.Map<List<Category>>(data);
            return categories;
        }
    }
}
