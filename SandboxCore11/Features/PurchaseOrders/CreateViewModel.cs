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

        public CreateViewModel(List<Supplier> suppliers)
        {
            this.suppliers = suppliers;
        }

        [DisplayName("Suppliers")]
        public List<SelectListItem> Suppliers
        {
            get
            {
                return suppliers.Select(x => new SelectListItem { Text = x.Name, Value = x.SupplierId.ToString() }).ToList();
            }
        }
    }
}
