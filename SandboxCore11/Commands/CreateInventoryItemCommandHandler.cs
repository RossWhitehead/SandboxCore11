namespace SandboxCore11.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Command;

    public class CreateInventoryItemCommandHandler : ICommandHandlerAsync<CreateInventoryItemCommand>
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public CreateInventoryItemCommandHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<CommandResult> HandleAsync(CreateInventoryItemCommand command)
        {
            var inventoryItem = mapper.Map<Data.InventoryItem>(command);
            db.Add(inventoryItem);
            await db.SaveChangesAsync();

            return new CommandResult(true, string.Empty);
        }
    }
}
