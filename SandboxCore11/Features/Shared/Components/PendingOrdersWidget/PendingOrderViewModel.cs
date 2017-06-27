namespace SandboxCore11.Features.Shared.Components.PendingOrdersWidget
{
    using System;

    public class PendingOrderViewModel
    {
        public int PurchaseOrderId { get; set; }

        public string Status { get; set; }

        public string SupplierName { get; set; }

        public DateTime RequestedDate { get; set; }

        public DateTime ConfirmedDate { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        public DateTime ReceivedDate { get; set; }
    }
}
