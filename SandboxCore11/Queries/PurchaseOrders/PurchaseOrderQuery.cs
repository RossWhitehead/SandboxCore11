namespace SandboxCore11.Queries
{
    using SandboxCore11.Infrastructure.Query;

    public class PurchaseOrderQuery : IQuery<PurchaseOrder>
    {
        public int Id { get; set; }
    }
}
