using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTaoCSDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenLoaiSPKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThuCung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiTC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenLoaiTCKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThuCung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quyen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NuocXuatXu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNuocXuatXu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenNuocXuatXuKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NuocXuatXu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MoTaKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiSanPhamID = table.Column<int>(type: "int", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenSanPhamKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_LoaiSanPhamID",
                        column: x => x.LoaiSanPhamID,
                        principalTable: "LoaiSanPham",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThuCung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNuocXuatXuID = table.Column<int>(type: "int", nullable: false),
                    LoaiThuCungID = table.Column<int>(type: "int", nullable: false),
                    TenThuCung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenThuCungKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Giong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TinhTrangSucKhoe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    NuocXuatXuID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuCung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThuCung_LoaiThuCung_LoaiThuCungID",
                        column: x => x.LoaiThuCungID,
                        principalTable: "LoaiThuCung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThuCung_NuocXuatXu_NuocXuatXuID",
                        column: x => x.NuocXuatXuID,
                        principalTable: "NuocXuatXu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DatHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungID = table.Column<int>(type: "int", nullable: false),
                    TinhTrangID = table.Column<int>(type: "int", nullable: false),
                    DienThoaiGiaoHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DiaChiGiaoHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayDatHang = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DatHang_NguoiDung_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "NguoiDung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatHang_TinhTrang_TinhTrangID",
                        column: x => x.TinhTrangID,
                        principalTable: "TinhTrang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatHang_ChiTiet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatHangID = table.Column<int>(type: "int", nullable: false),
                    ThuCungID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<short>(type: "smallint", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatHang_ChiTiet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DatHang_ChiTiet_DatHang_DatHangID",
                        column: x => x.DatHangID,
                        principalTable: "DatHang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatHang_ChiTiet_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatHang_ChiTiet_ThuCung_ThuCungID",
                        column: x => x.ThuCungID,
                        principalTable: "ThuCung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatHang_NguoiDungID",
                table: "DatHang",
                column: "NguoiDungID");

            migrationBuilder.CreateIndex(
                name: "IX_DatHang_TinhTrangID",
                table: "DatHang",
                column: "TinhTrangID");

            migrationBuilder.CreateIndex(
                name: "IX_DatHang_ChiTiet_DatHangID",
                table: "DatHang_ChiTiet",
                column: "DatHangID");

            migrationBuilder.CreateIndex(
                name: "IX_DatHang_ChiTiet_SanPhamID",
                table: "DatHang_ChiTiet",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_DatHang_ChiTiet_ThuCungID",
                table: "DatHang_ChiTiet",
                column: "ThuCungID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamID",
                table: "SanPham",
                column: "LoaiSanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_ThuCung_LoaiThuCungID",
                table: "ThuCung",
                column: "LoaiThuCungID");

            migrationBuilder.CreateIndex(
                name: "IX_ThuCung_NuocXuatXuID",
                table: "ThuCung",
                column: "NuocXuatXuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatHang_ChiTiet");

            migrationBuilder.DropTable(
                name: "DatHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "ThuCung");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "TinhTrang");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "LoaiThuCung");

            migrationBuilder.DropTable(
                name: "NuocXuatXu");
        }
    }
}
