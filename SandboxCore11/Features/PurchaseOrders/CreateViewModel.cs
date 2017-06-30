namespace SandboxCore11.Features.PurchaseOrders
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SandboxCore11.Queries;

    public class CreateViewModel
    {
        private List<Supplier> suppliers;
        private List<InventoryItem> inventoryItems;

        public CreateViewModel(List<Supplier> suppliers, List<InventoryItem> inventoryItems)
        {
            this.suppliers = suppliers;
            this.inventoryItems = inventoryItems;
        }

        [DisplayName("Suppliers")]
        public List<SelectListItem> Suppliers
        {
            get
            {
                return suppliers.Select(x => new SelectListItem { Text = x.Name, Value = x.SupplierId.ToString() }).ToList();
            }
        }

        public List<SelectListItem> InventoryItems
        {
            get
            {
                return inventoryItems.Select(x => new SelectListItem { Text = x.Name, Value = x.InventoryItemId.ToString() }).ToList();
            }
        }
    }
}
