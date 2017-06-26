﻿namespace SandboxCore11.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime RequestedDate { get; set; }

        public DateTime ConfirmedDate { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public DateTime LastUpdatedDate { get; } = DateTime.UtcNow;

        [Required]
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
