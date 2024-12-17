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
    public class LoaiThuCungController : Controller
    {
        private readonly PetShopDbContext _context;

        public LoaiThuCungController(PetShopDbContext context)
        {
            _context = context;
        }

        // GET: LoaiThuCung
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiThuCung.ToListAsync());
        }

        // GET: LoaiThuCung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiThuCung = await _context.LoaiThuCung
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loaiThuCung == null)
            {
                return NotFound();
            }

            return View(loaiThuCung);
        }

        // GET: LoaiThuCung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiThuCung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenLoaiTC,TenLoaiTCKhongDau")] LoaiThuCung loaiThuCung)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(loaiThuCung.TenLoaiTCKhongDau))
                {
                    loaiThuCung.TenLoaiTCKhongDau = loaiThuCung.TenLoaiTC.GenerateSlug();
                }
                _context.Add(loaiThuCung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiThuCung);
        }

        // GET: LoaiThuCung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiThuCung = await _context.LoaiThuCung.FindAsync(id);
            if (loaiThuCung == null)
            {
                return NotFound();
            }
            return View(loaiThuCung);
        }

        // POST: LoaiThuCung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenLoaiTC,TenLoaiTCKhongDau")] LoaiThuCung loaiThuCung)
        {
            if (id != loaiThuCung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(loaiThuCung.TenLoaiTCKhongDau))
                    {
                        loaiThuCung.TenLoaiTCKhongDau = loaiThuCung.TenLoaiTC.GenerateSlug();
                    }
                    _context.Update(loaiThuCung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiThuCungExists(loaiThuCung.ID))
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
            return View(loaiThuCung);
        }

        // GET: LoaiThuCung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiThuCung = await _context.LoaiThuCung
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loaiThuCung == null)
            {
                return NotFound();
            }

            return View(loaiThuCung);
        }

        // POST: LoaiThuCung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiThuCung = await _context.LoaiThuCung.FindAsync(id);
            if (loaiThuCung != null)
            {
                _context.LoaiThuCung.Remove(loaiThuCung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiThuCungExists(int id)
        {
            return _context.LoaiThuCung.Any(e => e.ID == id);
        }
    }
}
