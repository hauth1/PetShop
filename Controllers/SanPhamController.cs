using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SlugGenerator;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly PetShopDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SanPhamController(PetShopDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: SanPham
        public async Task<IActionResult> Index()
        {
            var petShopDbContext = _context.SanPham.Include(s => s.LoaiSanPham);
            return View(await petShopDbContext.ToListAsync());
        }

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPham/Create
        public IActionResult Create()
        {
            ViewData["LoaiSanPhamID"] = new SelectList(_context.LoaiSanPham, "ID", "TenLoaiSP");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LoaiSanPhamID,TenSanPham,TenSanPhamKhongDau,DonGia,SoLuong,DuLieuHinhAnh,MoTa")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(sanPham.TenSanPhamKhongDau))
                {
                    sanPham.TenSanPhamKhongDau = sanPham.TenSanPham.GenerateSlug();
                }
                string path = "";
                // Nếu hình ảnh không bỏ trống thì upload
                if (sanPham.DuLieuHinhAnh != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string folder = "/uploads/";
                    string fileExtension = Path.GetExtension(sanPham.DuLieuHinhAnh.FileName).ToLower();
                    string fileName = sanPham.TenSanPham;
                    string fileNameSluged = fileName.GenerateSlug();
                    path = fileNameSluged + fileExtension;
                    string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);
                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await sanPham.DuLieuHinhAnh.CopyToAsync(fileStream);
                    }
                }
                // Cập nhật đường dẫn vào CSDL
                sanPham.HinhAnh = path ?? null;
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiSanPhamID"] = new SelectList(_context.LoaiSanPham, "ID", "TenLoaiSP", sanPham.LoaiSanPhamID);
            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["LoaiSanPhamID"] = new SelectList(_context.LoaiSanPham, "ID", "TenLoaiSP", sanPham.LoaiSanPhamID);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LoaiSanPhamID,TenSanPham,TenSanPhamKhongDau,DonGia,SoLuong,DuLieuHinhAnh,MoTa")] SanPham sanPham)
        {
            if (id != sanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(sanPham.TenSanPhamKhongDau))
                    {
                        sanPham.TenSanPhamKhongDau = sanPham.TenSanPham.GenerateSlug();
                    }
                    string path = "";
                    // Nếu hình ảnh không bỏ trống thì upload ảnh mới
                    if (sanPham.DuLieuHinhAnh != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string folder = "/uploads/";
                        string fileExtension = Path.GetExtension(sanPham.DuLieuHinhAnh.FileName).ToLower();
                        string fileName = sanPham.TenSanPham;
                        string fileNameSluged = fileName.GenerateSlug();
                        path = fileNameSluged + fileExtension;
                        string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);
                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                        {
                            await sanPham.DuLieuHinhAnh.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(sanPham);
                    if (string.IsNullOrEmpty(path))
                        _context.Entry(sanPham).Property(x => x.HinhAnh).IsModified = false;
                    else
                        sanPham.HinhAnh = path;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.ID))
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
            ViewData["LoaiSanPhamID"] = new SelectList(_context.LoaiSanPham, "ID", "TenLoaiSP", sanPham.LoaiSanPhamID);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham != null)
            {
                // Xóa hình ảnh (nếu có)
                if (!string.IsNullOrEmpty(sanPham.HinhAnh))
                {
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "uploads", sanPham.HinhAnh);
                    if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);
                }
                _context.SanPham.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPham.Any(e => e.ID == id);
        }
    }
}
