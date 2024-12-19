using Microsoft.EntityFrameworkCore;

namespace PetShop.Models
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) { }
        public DbSet<LoaiThuCung> LoaiThuCung { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<NuocXuatXu> NuocXuatXu { get; set; }
        public DbSet<ThuCung> ThuCung { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<TinhTrang> TinhTrang { get; set; }
        public DbSet<DatHang> DatHang { get; set; }
        public DbSet<DatHang_ChiTiet> DatHang_ChiTiet { get; set; }
        public DbSet<GioHang> GioHang { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiThuCung>().ToTable("LoaiThuCung");
            modelBuilder.Entity<LoaiSanPham>().ToTable("LoaiSanPham");
            modelBuilder.Entity<NuocXuatXu>().ToTable("NuocXuatXu");
            modelBuilder.Entity<ThuCung>().ToTable("ThuCung");
            modelBuilder.Entity<SanPham>().ToTable("SanPham");
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
            modelBuilder.Entity<TinhTrang>().ToTable("TinhTrang");
            modelBuilder.Entity<DatHang>().ToTable("DatHang");
            modelBuilder.Entity<DatHang_ChiTiet>().ToTable("DatHang_ChiTiet");
            modelBuilder.Entity<GioHang>().ToTable("GioHang");
        }
    }
}
