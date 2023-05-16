using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMS.Entities.Models;

namespace PMS.WebUI.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class StoresController : Controller
    {
        private readonly PmsContext _context = new PmsContext();

        // GET: ManagementPanel/Stores
        public async Task<IActionResult> Index()
        {
            var pmsContext = _context.Stores.Include(s => s.Manager);
            return View(await pmsContext.ToListAsync());
        }

        // GET: ManagementPanel/Stores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .Include(s => s.Manager)
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: ManagementPanel/Stores/Create
        public IActionResult Create()
        {
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "Email");
            return View();
        }

        // POST: ManagementPanel/Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Store store)
        {
            if (ModelState.IsValid)
            {
                _context.Add(store);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "Email", store.ManagerId);
            return View(store);
        }

        // GET: ManagementPanel/Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "Email", store.ManagerId);
            return View(store);
        }

        // POST: ManagementPanel/Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Store editStores = await _context.Stores.FindAsync(store.StoreId);

                    editStores.Name = store.Name;
                    editStores.Email = store.Email;
                    editStores.Phone = store.Phone;
                    editStores.Address = store.Address;
                    editStores.Manager.Email = store.Manager.Email;

                    _context.Update(store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "Email", store.ManagerId);
            return View(store);
        }
    }
}
