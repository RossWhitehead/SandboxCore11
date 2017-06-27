namespace SandboxCore11.Commands
{
    using SandboxCore11.Infrastructure.Command;

    public class CreateInventoryItemCommand : ICommand
    {
        public CreateInventoryItemCommand(string name, string description, int reorderLevel, int reorderQuantity, int brandId, int categoryId)
        {
            this.Name = name;
            this.Description = description;
            this.ReorderLevel = reorderLevel;
            this.ReorderQuantity = reorderQuantity;
            this.BrandId = brandId;
            this.CategoryId = categoryId;
        }

        public string Name { get; }

        public string Description { get; }

        public int ReorderLevel { get; }

        public int ReorderQuantity { get; }

        public int BrandId { get; }

        public int CategoryId { get; }
    }
}
