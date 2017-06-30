namespace SandboxCore11.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        [Required]
        public string Status { get; set; } = "Requested";

        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ConfirmedDate { get; set; }

        public DateTime? ExpectedDeliveryDate { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime LastUpdatedDate { get; } = DateTime.UtcNow;

        [Required]
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
