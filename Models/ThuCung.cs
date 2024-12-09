using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class ThuCung
    {
        public int ID { get; set; }
        public int TenNuocXuatXuID { get; set; }
        public int LoaiThuCungID { get; set; }

        [StringLength(255)]
        public string TenThuCung { get; set; }

        [StringLength(255)]
        public string? TenThuCungKhongDau { get; set; }

        [StringLength(255)]
        public string Giong { get; set; }

        public int Tuoi { get; set; }

        [StringLength(255)]
        public string GioiTinh { get; set; }

        [StringLength(255)]
        public string MauSac { get; set; }

        [StringLength(255)]
        public string TinhTrangSucKhoe { get; set; }

        public int DonGia { get; set; }
        public int SoLuong { get; set; }

        [StringLength(255)]
        public string? HinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string? MoTa { get; set; }

        public NuocXuatXu? NuocXuatXu { get; set; }
        public LoaiThuCung? LoaiThuCung { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
    }
}
