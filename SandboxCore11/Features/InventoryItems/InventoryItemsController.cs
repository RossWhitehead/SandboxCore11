namespace SandboxCore11.Features.InventoryItems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using SandboxCore11.Commands;
    using SandboxCore11.Data;
    using SandboxCore11.Infrastructure.Command;
    using SandboxCore11.Infrastructure.Query;
    using SandboxCore11.Queries;

    [Route("InventoryItems")]
    public class InventoryItemsController : Controller
    {
        private IMapper mapper;
        private IMemoryCache cache;

        public InventoryItemsController(IMapper mapper, IMemoryCache cache)
        {
            this.mapper = mapper;
            this.cache = cache;
        }

        // GET: InventoryItems
        [HttpGet("Index")]
        public async Task<IActionResult> Index(
            [FromServices]IQueryHandlerAsync<InventoryItemsQuery, List<Queries.InventoryItem>> queryHandler)
        {
            var inventoryItems = await queryHandler.HandleAsync(new InventoryItemsQuery());

            return View(inventoryItems);
        }

        // GET: InventoryItems/Details/5
        [HttpGet("Details/{InventoryItemId}")]
        public async Task<IActionResult> Details(
            [FromServices]IQueryHandlerAsync<InventoryItemQuery, Queries.InventoryItem> queryHandler,
            InventoryItemQuery query)
        {
            var inventoryItem = await queryHandler.HandleAsync(query);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            var vm = mapper.Map<DetailsViewModel>(inventoryItem);

            return View(vm);
        }

        // GET: InventoryItems/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create(
            [FromServices]IQueryHandlerAsync<BrandsQuery, List<Queries.Brand>> brandsQueryHandler,
            [FromServices]IQueryHandlerAsync<CategoriesQuery, List<Queries.Category>> categoriesQueryHandler)
        {
            var brands = await brandsQueryHandler.HandleAsync(new BrandsQuery());
            var categories = await categoriesQueryHandler.HandleAsync(new CategoriesQuery());

            var vm = new CreateViewModel() { Brands = brands, Categories = categories };

            return View(vm);
        }

        // POST: InventoryItems/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [FromServices]ICommandHandlerAsync<CreateInventoryItemCommand> createCommandHandler,
            CreateInventoryItemCommand createCommand)
        {
                await createCommandHandler.HandleAsync(createCommand);

                return RedirectToAction("Index");
        }

        // GET: InventoryItems/Edit/5
        [HttpGet("Edit/{InventoryItemId}")]
        public async Task<IActionResult> Edit(
            [FromServices]IQueryHandlerAsync<InventoryItemQuery, Queries.InventoryItem> queryHandler,
            InventoryItemQuery query,
            [FromServices]IQueryHandlerAsync<BrandsQuery, List<Queries.Brand>> brandsQueryHandler,
            [FromServices]IQueryHandlerAsync<CategoriesQuery, List<Queries.Category>> categoriesQueryHandler)
        {
            var inventoryItem = await queryHandler.HandleAsync(query);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            var brands = await brandsQueryHandler.HandleAsync(new BrandsQuery());
            var categories = await categoriesQueryHandler.HandleAsync(new CategoriesQuery());

            var vm = mapper.Map<EditViewModel>(inventoryItem);
            vm.Brands = brands;
            vm.Categories = categories;

            return View(vm);
        }

        // POST: InventoryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{InventoryItemId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [FromServices] ICommandHandlerAsync<EditInventoryItemCommand> editCommandHandler, 
            EditInventoryItemCommand editCommand)
        {
            await editCommandHandler.HandleAsync(editCommand);
            return RedirectToAction("Index");
        }

        // GET: InventoryItems/Delete/5
        [HttpPost("Delete/{inventoryItemId}")]
        public async Task<IActionResult> Delete(
            [FromServices]IQueryHandlerAsync<InventoryItemQuery, Queries.InventoryItem> inventoryItemQueryHandler,
            InventoryItemQuery inventoryItemQuery)
        {
            var inventoryItem = await inventoryItemQueryHandler.HandleAsync(inventoryItemQuery);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            var vm = mapper.Map<DeleteViewModel>(inventoryItem);

            return View(vm);
        }

        // POST: InventoryItems/Delete/5
        [HttpPost("Delete/{inventoryItemId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(
            [FromServices]ICommandHandlerAsync<DeleteInventoryItemCommand> deleteCommandHandler,
            DeleteInventoryItemCommand deleteCommand)
        {
            var result = await deleteCommandHandler.HandleAsync(deleteCommand);
            return RedirectToAction("Index");
        }

        [HttpGet("ValidateName")]
        public async Task<IActionResult> ValidateName(
            [FromServices]IQueryHandlerAsync<InventoryItemNameExistsQuery, bool> inventoryItemNameExistsQueryHandler,
            InventoryItemNameExistsQuery inventoryItemNameExistsQuery,
            string currentName)
        {
            var exists = false;
            if (inventoryItemNameExistsQuery.Name != currentName)
            {
                exists = await inventoryItemNameExistsQueryHandler.HandleAsync(inventoryItemNameExistsQuery);
            }

            if (exists)
            {
                return Json($"An inventory item with the name ({inventoryItemNameExistsQuery.Name}) already exists.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
