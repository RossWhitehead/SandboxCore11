namespace SandboxCore11.Commands.CreateInventoryItem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Command;

    public class CreateInventoryItemCommandHandler : ICommandHandlerAsync<CreateInventoryItemCommand>
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private AbstractValidator<CreateInventoryItemCommand> validator;

        public CreateInventoryItemCommandHandler(ApplicationDbContext db, IMapper mapper, AbstractValidator<CreateInventoryItemCommand> validator)
        {
            this.db = db;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<CommandResult> HandleAsync(CreateInventoryItemCommand command)
        {
            var isValid = await Validate(command);

            var inventoryItem = mapper.Map<Data.InventoryItem>(command);
            db.Add(inventoryItem);
            await db.SaveChangesAsync();

            return new CommandResult(true, string.Empty);
        }

        private async Task<bool> Validate(CreateInventoryItemCommand command)
        {
            await validator.ValidateAndThrowAsync(command);
            return true;
        }
    }
}
