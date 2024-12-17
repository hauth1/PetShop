using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PetShop.Models;
using SlugGenerator;

namespace PetShop.Controllers
{
    public class ThuCungController : Controller
    {
        private readonly PetShopDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ThuCungController(PetShopDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
            ViewData["TenNuocXuatXuID"] = new SelectList(_context.NuocXuatXu, "ID", "TenNuocXuatXu");
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "TenLoaiTC");
            return View();
        }

        // POST: ThuCung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenNuocXuatXuID,LoaiThuCungID,TenThuCung,TenThuCungKhongDau,Giong,Tuoi,GioiTinh,MauSac,TinhTrangSucKhoe,DonGia,SoLuong,DuLieuHinhAnh,MoTa")] ThuCung thuCung)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(thuCung.TenThuCungKhongDau))
                {
                    thuCung.TenThuCungKhongDau = thuCung.TenThuCung.GenerateSlug();
                }
                string path = "";
                // Nếu hình ảnh không bỏ trống thì upload
                if (thuCung.DuLieuHinhAnh != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string folder = "/uploads/";
                    string fileExtension = Path.GetExtension(thuCung.DuLieuHinhAnh.FileName).ToLower();
                    string fileName = thuCung.TenThuCung;
                    string fileNameSluged = fileName.GenerateSlug();
                    path = fileNameSluged + fileExtension;
                    string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);
                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await thuCung.DuLieuHinhAnh.CopyToAsync(fileStream);
                    }
                } 
                // Cập nhật đường dẫn vào CSDL
                thuCung.HinhAnh = path ?? null;
                _context.Add(thuCung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "TenLoaiTC", thuCung.LoaiThuCungID);
            ViewData["TenNuocXuatXuID"] = new SelectList(_context.NuocXuatXu, "ID", "TenNuocXuatXu", thuCung.TenNuocXuatXuID);
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
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "TenLoaiTC", thuCung.LoaiThuCungID);
            ViewData["TenNuocXuatXuID"] = new SelectList(_context.NuocXuatXu, "ID", "TenNuocXuatXu", thuCung.TenNuocXuatXuID);
            return View(thuCung);
        }

        // POST: ThuCung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenNuocXuatXuID,LoaiThuCungID,TenThuCung,TenThuCungKhongDau,Giong,Tuoi,GioiTinh,MauSac,TinhTrangSucKhoe,DonGia,SoLuong,DuLieuHinhAnh,MoTa")] ThuCung thuCung)
        {
            if (id != thuCung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(thuCung.TenThuCungKhongDau))
                    {
                        thuCung.TenThuCungKhongDau = thuCung.TenThuCung.GenerateSlug();
                    }

                    string path = "";
                    // Nếu hình ảnh không bỏ trống thì upload ảnh mới
                    if (thuCung.DuLieuHinhAnh != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string folder = "/uploads/";
                        string fileExtension = Path.GetExtension(thuCung.DuLieuHinhAnh.FileName).ToLower();
                        string fileName = thuCung.TenThuCung;
                        string fileNameSluged = fileName.GenerateSlug();
                        path = fileNameSluged + fileExtension;
                        string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);
                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                        {
                            await thuCung.DuLieuHinhAnh.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(thuCung);
                    if (string.IsNullOrEmpty(path))
                        _context.Entry(thuCung).Property(x => x.HinhAnh).IsModified = false;
                    else
                        thuCung.HinhAnh = path;
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
            ViewData["LoaiThuCungID"] = new SelectList(_context.LoaiThuCung, "ID", "TenLoaiTC", thuCung.LoaiThuCungID);
            ViewData["TenNuocXuatXuID"] = new SelectList(_context.NuocXuatXu, "ID", "TenNuocXuatXu", thuCung.TenNuocXuatXuID);
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
                if (!string.IsNullOrEmpty(thuCung.HinhAnh))
                {
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "uploads", thuCung.HinhAnh);
                    if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);
                }
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
