namespace SandboxCore11.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class PurchaseOrderDetail
    {
        public int PurchaseOrderDetailId { get; set; }

        [Required]
        public int InventoryItemId { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsReceived { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
