namespace SandboxCore11.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SandboxCore11.Data;

    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public void AddToOrder(PurchaseOrderDetail purchaseOrderDetail)
        {
            var existing = PurchaseOrderDetails.Where(pod => pod.InventoryItem.Id == purchaseOrderDetail.InventoryItem.Id).FirstOrDefault();
            if (existing == null)
            {
                PurchaseOrderDetails.Add(purchaseOrderDetail);
            }
            else
            {
                existing.Quantity += purchaseOrderDetail.Quantity;
            }
        }

        public void RemoveFromOrder(int purchaseOrderDetailId)
        {
            PurchaseOrderDetails.RemoveAll(pod => pod.InventoryItemId == purchaseOrderDetailId);
        }
    }
}
