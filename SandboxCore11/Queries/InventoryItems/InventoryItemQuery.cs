namespace SandboxCore11.Queries
{
    using SandboxCore11.Infrastructure.Query;

    public class InventoryItemQuery : IQuery<InventoryItem>
    {
        public int InventoryItemId { get; set; }
    }
}
