using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PMS.Entities.Models;
using PMS.WebUI.Areas.ManagementPanel.Helpers;

namespace PMS.WebUI.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class MainPagesController : Controller
    {
        private readonly PmsContext _context = new PmsContext();

        private readonly IWebHostEnvironment _hostEnvironment;

        public MainPagesController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        // GET: ManagementPanel/MainPages
        public async Task<IActionResult> Index()
        {
              return View(await _context.MainPages.ToListAsync());
        }

        // GET: ManagementPanel/MainPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/MainPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainPage mainPage, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    mainPage.ImageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                }
                _context.Add(mainPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainPage);
        }

        // GET: ManagementPanel/MainPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MainPages == null)
            {
                return NotFound();
            }

            var mainPage = await _context.MainPages.FindAsync(id);
            if (mainPage == null)
            {
                return NotFound();
            }
            return View(mainPage);
        }

        // POST: ManagementPanel/MainPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MainPage mainPage, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MainPage editmainpage = await _context.MainPages.FirstOrDefaultAsync(r => r.MainPageId == mainPage.MainPageId);
                    if (img != null)
                    {
                        editmainpage.ImageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                    }

                    editmainpage.Title = mainPage.Title;
                    editmainpage.Notice = mainPage.Notice;
                    editmainpage.Description = mainPage.Description;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(mainPage);
        }

    }
}
