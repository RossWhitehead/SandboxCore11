namespace SandboxCore11.Commands
{
    using System.Collections.Generic;
    using SandboxCore11.Infrastructure.Command;

    public class CreatePurchaseOrderCommand : ICommand
    {
        public int SupplierId { get; set; }

        public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
