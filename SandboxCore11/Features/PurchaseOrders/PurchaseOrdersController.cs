namespace SandboxCore11.Features.PurchaseOrders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SandboxCore11.Commands;
    using SandboxCore11.Infrastructure.Command;
    using SandboxCore11.Infrastructure.Query;
    using SandboxCore11.Queries;

    public class PurchaseOrdersController : Controller
    {
        public PurchaseOrdersController()
        {
        }

        // GET: PurchaseOrders
        public async Task<IActionResult> Index([FromServices]IQueryHandlerAsync<PurchaseOrdersQuery, List<PurchaseOrder>> queryHandler)
        {
            var vm = await queryHandler.HandleAsync(new PurchaseOrdersQuery());
            return View(vm);
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(
            PurchaseOrderQuery query,
            [FromServices]IQueryHandlerAsync<PurchaseOrderQuery, PurchaseOrder> queryHandler)
        {
            var purchaseOrder = await queryHandler.HandleAsync(query);

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public async Task<IActionResult> Create(
            [FromServices]IQueryHandlerAsync<SuppliersQuery, List<Supplier>> suppliersQueryHandler,
            [FromServices]IQueryHandlerAsync<InventoryItemsQuery, List<InventoryItem>> inventoryItemsQueryHandler)
        {
            var suppliers = await suppliersQueryHandler.HandleAsync(new SuppliersQuery());

            var inventoryItems = await inventoryItemsQueryHandler.HandleAsync(new InventoryItemsQuery());

            var vm = new CreateViewModel(suppliers, inventoryItems);

            return View(vm);
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [FromServices]ICommandHandlerAsync<CreatePurchaseOrderCommand> createCommandHandler,
            CreatePurchaseOrderCommand createCommand)
        {
            var result = await createCommandHandler.HandleAsync(createCommand);

            return RedirectToAction("Index");
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var purchaseOrder = await _context.PurchaseOrders.SingleOrDefaultAsync(m => m.PurchaseOrderId == id);
            //if (purchaseOrder == null)
            //{
            //    return NotFound();
            //}
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", purchaseOrder.SupplierId);
            //return View(purchaseOrder);

            throw new NotImplementedException();
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseOrderId,Status,RequestedDate,ConfirmedDate,ExpectedDeliveryDate,ReceivedDate,SupplierId")] Data.PurchaseOrder purchaseOrder)
        {
            //if (id != purchaseOrder.PurchaseOrderId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(purchaseOrder);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PurchaseOrderExists(purchaseOrder.PurchaseOrderId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction("Index");
            //}
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", purchaseOrder.SupplierId);
            //return View(purchaseOrder);

            throw new NotImplementedException();
        }
    }
}
