using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DatHang_ChiTietController : Controller
    {
        private readonly PetShopDbContext _context;

        public DatHang_ChiTietController(PetShopDbContext context)
        {
            _context = context;
        }

        // GET: DatHang_ChiTiet
        public async Task<IActionResult> Index()
        {
            var petShopDbContext = _context.DatHang_ChiTiet.Include(d => d.DatHang).Include(d => d.SanPham).Include(d => d.ThuCung);
            return View(await petShopDbContext.ToListAsync());
        }

        // GET: DatHang_ChiTiet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datHang_ChiTiet = await _context.DatHang_ChiTiet
                .Include(d => d.DatHang)
                .Include(d => d.SanPham)
                .Include(d => d.ThuCung)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (datHang_ChiTiet == null)
            {
                return NotFound();
            }

            return View(datHang_ChiTiet);
        }

        // GET: DatHang_ChiTiet/Create
        public IActionResult Create()
        {
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID");
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID");
            ViewData["ThuCungID"] = new SelectList(_context.ThuCung, "ID", "ID");
            return View();
        }

        // POST: DatHang_ChiTiet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DatHangID,ThuCungID,SanPhamID,SoLuong,DonGia")] DatHang_ChiTiet datHang_ChiTiet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datHang_ChiTiet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID", datHang_ChiTiet.DatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID", datHang_ChiTiet.SanPhamID);
            ViewData["ThuCungID"] = new SelectList(_context.ThuCung, "ID", "ID", datHang_ChiTiet.ThuCungID);
            return View(datHang_ChiTiet);
        }

        // GET: DatHang_ChiTiet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datHang_ChiTiet = await _context.DatHang_ChiTiet.FindAsync(id);
            if (datHang_ChiTiet == null)
            {
                return NotFound();
            }
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID", datHang_ChiTiet.DatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID", datHang_ChiTiet.SanPhamID);
            ViewData["ThuCungID"] = new SelectList(_context.ThuCung, "ID", "ID", datHang_ChiTiet.ThuCungID);
            return View(datHang_ChiTiet);
        }

        // POST: DatHang_ChiTiet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DatHangID,ThuCungID,SanPhamID,SoLuong,DonGia")] DatHang_ChiTiet datHang_ChiTiet)
        {
            if (id != datHang_ChiTiet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datHang_ChiTiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatHang_ChiTietExists(datHang_ChiTiet.ID))
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
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID", datHang_ChiTiet.DatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID", datHang_ChiTiet.SanPhamID);
            ViewData["ThuCungID"] = new SelectList(_context.ThuCung, "ID", "ID", datHang_ChiTiet.ThuCungID);
            return View(datHang_ChiTiet);
        }

        // GET: DatHang_ChiTiet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datHang_ChiTiet = await _context.DatHang_ChiTiet
                .Include(d => d.DatHang)
                .Include(d => d.SanPham)
                .Include(d => d.ThuCung)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (datHang_ChiTiet == null)
            {
                return NotFound();
            }

            return View(datHang_ChiTiet);
        }

        // POST: DatHang_ChiTiet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datHang_ChiTiet = await _context.DatHang_ChiTiet.FindAsync(id);
            if (datHang_ChiTiet != null)
            {
                _context.DatHang_ChiTiet.Remove(datHang_ChiTiet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatHang_ChiTietExists(int id)
        {
            return _context.DatHang_ChiTiet.Any(e => e.ID == id);
        }
    }
}
