using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using SlugGenerator;

namespace PetShop.Controllers
{
    public class NuocXuatXuController : Controller
    {
        private readonly PetShopDbContext _context;

        public NuocXuatXuController(PetShopDbContext context)
        {
            _context = context;
        }

        // GET: NuocXuatXu
        public async Task<IActionResult> Index()
        {
            return View(await _context.NuocXuatXu.ToListAsync());
        }

        // GET: NuocXuatXu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuocXuatXu = await _context.NuocXuatXu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nuocXuatXu == null)
            {
                return NotFound();
            }

            return View(nuocXuatXu);
        }

        // GET: NuocXuatXu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NuocXuatXu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenNuocXuatXu,TenNuocXuatXuKhongDau")] NuocXuatXu nuocXuatXu)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(nuocXuatXu.TenNuocXuatXuKhongDau))
                {
                    nuocXuatXu.TenNuocXuatXuKhongDau = nuocXuatXu.TenNuocXuatXu.GenerateSlug();
                }
                _context.Add(nuocXuatXu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nuocXuatXu);
        }

        // GET: NuocXuatXu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuocXuatXu = await _context.NuocXuatXu.FindAsync(id);
            if (nuocXuatXu == null)
            {
                return NotFound();
            }
            return View(nuocXuatXu);
        }

        // POST: NuocXuatXu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenNuocXuatXu,TenNuocXuatXuKhongDau")] NuocXuatXu nuocXuatXu)
        {
            if (id != nuocXuatXu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(nuocXuatXu.TenNuocXuatXuKhongDau))
                    {
                        nuocXuatXu.TenNuocXuatXuKhongDau = nuocXuatXu.TenNuocXuatXu.GenerateSlug();
                    }
                    _context.Update(nuocXuatXu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NuocXuatXuExists(nuocXuatXu.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nuocXuatXu);
        }

        // GET: NuocXuatXu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuocXuatXu = await _context.NuocXuatXu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nuocXuatXu == null)
            {
                return NotFound();
            }

            return View(nuocXuatXu);
        }

        // POST: NuocXuatXu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nuocXuatXu = await _context.NuocXuatXu.FindAsync(id);
            if (nuocXuatXu != null)
            {
                _context.NuocXuatXu.Remove(nuocXuatXu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NuocXuatXuExists(int id)
        {
            return _context.NuocXuatXu.Any(e => e.ID == id);
        }
    }
}
