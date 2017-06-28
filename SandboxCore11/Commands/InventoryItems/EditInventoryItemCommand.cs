namespace SandboxCore11.Commands
{
    using SandboxCore11.Infrastructure.Command;

    public class EditInventoryItemCommand : ICommand
    {
        public EditInventoryItemCommand(int inventoryItemId, string name, string description, int reorderLevel, int reorderQuantity, int brandId, int categoryId)
        {
            this.InventoryItemId = inventoryItemId;
            this.Name = name;
            this.Description = description;
            this.ReorderLevel = reorderLevel;
            this.ReorderQuantity = reorderQuantity;
            this.BrandId = brandId;
            this.CategoryId = categoryId;
        }

        public int InventoryItemId { get; }

        public string Name { get; }

        public string Description { get; }

        public int ReorderLevel { get; }

        public int ReorderQuantity { get; }

        public int BrandId { get; }

        public int CategoryId { get; }
    }
}
