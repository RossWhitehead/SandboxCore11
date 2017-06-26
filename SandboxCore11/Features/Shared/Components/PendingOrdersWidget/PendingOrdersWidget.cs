namespace SandboxCore11.Features.Shared.Components.PendingOrdersWidget
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SandboxCore11.Data;

    public class PendingOrdersWidget : ViewComponent
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public PendingOrdersWidget(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var purchaseOrders = db.PurchaseOrders.Include(po => po.Supplier);
            var vm = mapper.Map<List<PendingOrderViewModel>>(purchaseOrders);

            return View(vm);
        }
    }
}
