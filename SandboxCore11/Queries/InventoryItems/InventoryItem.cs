namespace SandboxCore11.Queries
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
