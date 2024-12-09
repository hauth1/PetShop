using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class ThuCungController : Controller
    {
        private readonly PetShopDbContext _context;

        public ThuCungController(PetShopDbContext context)
        {
            _context = context;
        }

        // GET: ThuCung
        public async Task<IActionResult> Index()
        {
            var petShopDbContext = _context.ThuCung.Include(t => t.LoaiThuCung);
            return View(await petShopDbContext.ToListAsync());
        }

        // GET: ThuCung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuCung = await _context.ThuCung
                .Include(t => t.LoaiThuCung)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thuCung == null)
            {
                return NotFound();
            }

            return View(thuCung);
        }

        // GET: ThuCung/Create
        public IActionResult Create()
        {
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "ID");
            return View();
        }

        // POST: ThuCung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenNuocXuatXuID,LoaiThuCungID,TenThuCung,TenThuCungKhongDau,Giong,Tuoi,GioiTinh,MauSac,TinhTrangSucKhoe,DonGia,SoLuong,HinhAnh,MoTa")] ThuCung thuCung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuCung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "ID", thuCung.LoaiThuCungID);
            return View(thuCung);
        }

        // GET: ThuCung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuCung = await _context.ThuCung.FindAsync(id);
            if (thuCung == null)
            {
                return NotFound();
            }
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "ID", thuCung.LoaiThuCungID);
            return View(thuCung);
        }

        // POST: ThuCung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenNuocXuatXuID,LoaiThuCungID,TenThuCung,TenThuCungKhongDau,Giong,Tuoi,GioiTinh,MauSac,TinhTrangSucKhoe,DonGia,SoLuong,HinhAnh,MoTa")] ThuCung thuCung)
        {
            if (id != thuCung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuCung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuCungExists(thuCung.ID))
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
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "ID", thuCung.LoaiThuCungID);
            return View(thuCung);
        }

        // GET: ThuCung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuCung = await _context.ThuCung
                .Include(t => t.LoaiThuCung)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thuCung == null)
            {
                return NotFound();
            }

            return View(thuCung);
        }

        // POST: ThuCung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuCung = await _context.ThuCung.FindAsync(id);
            if (thuCung != null)
            {
                _context.ThuCung.Remove(thuCung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuCungExists(int id)
        {
            return _context.ThuCung.Any(e => e.ID == id);
        }
    }
}
