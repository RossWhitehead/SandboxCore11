namespace SandboxCore11.Features.InventoryItems
{
    public class DeleteViewModel
    {
        public int InventoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }
    }
}
