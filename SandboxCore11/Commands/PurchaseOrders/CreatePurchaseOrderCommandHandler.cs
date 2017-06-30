namespace SandboxCore11.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Command;

    public class CreatePurchaseOrderCommandHandler : ICommandHandlerAsync<CreatePurchaseOrderCommand>
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private AbstractValidator<CreatePurchaseOrderCommand> validator;

        public CreatePurchaseOrderCommandHandler(ApplicationDbContext db, IMapper mapper, AbstractValidator<CreatePurchaseOrderCommand> validator)
        {
            this.db = db;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<CommandResult> HandleAsync(CreatePurchaseOrderCommand command)
        {
            var isValid = await Validate(command);

            var purchaseOrder = mapper.Map<Data.PurchaseOrder>(command);
            db.Add(purchaseOrder);
            await db.SaveChangesAsync();

            return new CommandResult(true, string.Empty);
        }

        private async Task<bool> Validate(CreatePurchaseOrderCommand command)
        {
            await validator.ValidateAndThrowAsync(command);
            return true;
        }
    }
}
