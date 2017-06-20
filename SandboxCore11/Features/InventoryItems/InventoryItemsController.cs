using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SandboxCore11.Data;
using AutoMapper;

namespace SandboxCore11.Features.InventoryItems
{
    public class InventoryItemsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private IMapper mapper;

        public InventoryItemsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // GET: InventoryItems
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.InventoryItems.ToListAsync());
        }

        // GET: InventoryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await dbContext.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // GET: InventoryItems/Create
        public async Task<IActionResult> Create()
        {
            var brands = await dbContext.Brands.ToListAsync();
            var categories = await dbContext.Categories.ToListAsync();

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
                dbContext.Add(inventoryItem);
                await dbContext.SaveChangesAsync();
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

            var inventoryItem = await dbContext.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ReorderLevel,ReorderQuantity")] InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(inventoryItem);
                    await dbContext.SaveChangesAsync();
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

            var inventoryItem = await dbContext.InventoryItems
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
            var inventoryItem = await dbContext.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);
            dbContext.InventoryItems.Remove(inventoryItem);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryItemExists(int id)
        {
            return dbContext.InventoryItems.Any(e => e.Id == id);
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
