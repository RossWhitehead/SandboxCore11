namespace SandboxCore11.Features.InventoryItems
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using SandboxCore11.Data;

    public class InventoryItemsController : Controller
    {
        private readonly ApplicationDbContext db;
        private IMapper mapper;
        private IMemoryCache cache;

        public InventoryItemsController(ApplicationDbContext db, IMapper mapper, IMemoryCache cache)
        {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }

        // GET: InventoryItems
        public async Task<IActionResult> Index([FromServices]IQueryHandlerAsync<InventoryItemsQuery, List<Queries.InventoryItem>> queryHandler)
        {
            var inventoryItems = await queryHandler.HandleAsync(new InventoryItemsQuery());
            return View(inventoryItems);
        }

        // GET: InventoryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await db.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // GET: InventoryItems/Create
        public async Task<IActionResult> Create()
        {
            var brands = await db.Brands.ToListAsync();
            var categories = await db.Categories.ToListAsync();

            var vm = new CreateViewModel() { Brands = brands, Categories = categories };

            return View(vm);
        }

        // POST: InventoryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,BrandId,CategoryId,ReorderLevel,ReorderQuantity")] CreateEditModel createEditModel)
        {
            if (ModelState.IsValid)
            {
                var inventoryItem = mapper.Map<InventoryItem>(createEditModel);
                db.Add(inventoryItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: InventoryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await db.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return View(inventoryItem);
        }

        // POST: InventoryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ReorderLevel,ReorderQuantity")] Data.InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(inventoryItem);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryItemExists(inventoryItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(inventoryItem);
        }

        // GET: InventoryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await db.InventoryItems
                .SingleOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // POST: InventoryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryItem = await db.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);
            db.InventoryItems.Remove(inventoryItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryItemExists(int id)
        {
            return db.InventoryItems.Any(e => e.Id == id);
        }

        public IActionResult ValidateName(string name)
        {
            if (name == "Item 1")
            {
                return Json($"An inventory item with the name ({name}) already exists.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
