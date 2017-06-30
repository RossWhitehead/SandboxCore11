namespace SandboxCore11.Queries
{
    using System;
    using System.ComponentModel;

    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public string Status { get; set; }

        [DisplayName("Requested")]
        public DateTime RequestedDate { get; set; }

        [DisplayName("Confirmed")]
        public DateTime? ConfirmedDate { get; set; }

        [DisplayName("Expected")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [DisplayName("Received")]
        public DateTime? ReceivedDate { get; set; }

        [DisplayName("Supplier")]
        public string SupplierName { get; set; }
    }
}
