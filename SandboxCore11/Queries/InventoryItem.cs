namespace SandboxCore11.Queries
{
    public class InventoryItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }
    }
}
