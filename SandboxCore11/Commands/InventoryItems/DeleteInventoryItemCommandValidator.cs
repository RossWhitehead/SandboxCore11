namespace SandboxCore11.Commands
{
    using System.Linq;
    using FluentValidation;
    using SandboxCore11.Data;

    public class DeleteInventoryItemCommandValidator : AbstractValidator<DeleteInventoryItemCommand>
    {
        private ApplicationDbContext db;

        public DeleteInventoryItemCommandValidator(ApplicationDbContext db)
        {
            this.db = db;

            RuleFor(x => x.InventoryItemId).Must(BeAValidInventoryItem).WithMessage("Inventory item cannot be deleted.");
        }

        private bool BeAValidInventoryItem(int inventoryItemId)
        {
            return db.InventoryItems.Where(x => x.InventoryItemId == inventoryItemId).Count() == 1;
        }
    }
}
