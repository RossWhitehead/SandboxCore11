namespace SandboxCore11.Queries
{
    using SandboxCore11.Infrastructure.Query;

    public class InventoryItemNameExistsQuery : IQuery<bool>
    {
        public string Name { get; set; }
    }
}
