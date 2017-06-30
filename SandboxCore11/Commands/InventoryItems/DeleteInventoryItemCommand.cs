namespace SandboxCore11.Commands
{
    using SandboxCore11.Infrastructure.Command;

    public class DeleteInventoryItemCommand : ICommand
    {
        public DeleteInventoryItemCommand(int inventoryItemId)
        {
            this.InventoryItemId = inventoryItemId;
        }

        public int InventoryItemId { get; }
    }
}
