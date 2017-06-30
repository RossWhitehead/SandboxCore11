namespace SandboxCore11.Commands
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Command;

    public class DeleteInventoryItemCommandHandler : ICommandHandlerAsync<DeleteInventoryItemCommand>
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private AbstractValidator<DeleteInventoryItemCommand> validator;

        public DeleteInventoryItemCommandHandler(ApplicationDbContext db, IMapper mapper, AbstractValidator<DeleteInventoryItemCommand> validator)
        {
            this.db = db;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<CommandResult> HandleAsync(DeleteInventoryItemCommand command)
        {
            var isValid = await Validate(command);

            db.InventoryItems.Remove(new InventoryItem() { InventoryItemId = command.InventoryItemId });
            await db.SaveChangesAsync();

            return new CommandResult(true, string.Empty);
        }

        private async Task<bool> Validate(DeleteInventoryItemCommand command)
        {
            await validator.ValidateAndThrowAsync(command);
            return true;
        }
    }
}
