namespace SandboxCore11.Commands
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Command;

    public class EditInventoryItemCommandHandler : ICommandHandlerAsync<EditInventoryItemCommand>
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private AbstractValidator<EditInventoryItemCommand> validator;

        public EditInventoryItemCommandHandler(ApplicationDbContext db, IMapper mapper, AbstractValidator<EditInventoryItemCommand> validator)
        {
            this.db = db;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<CommandResult> HandleAsync(EditInventoryItemCommand command)
        {
            var isValid = await Validate(command);

            var inventoryItem = mapper.Map<Data.InventoryItem>(command);
            db.Add(inventoryItem);
            await db.SaveChangesAsync();

            return new CommandResult(true, string.Empty);
        }

        private async Task<bool> Validate(EditInventoryItemCommand command)
        {
            await validator.ValidateAndThrowAsync(command);
            return true;
        }
    }
}
