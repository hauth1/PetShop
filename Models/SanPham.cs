using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class SanPham
    {
        public int ID { get; set; }
        public int LoaiSanPhamID { get; set; }

        [StringLength(255)]
        public string TenSanPham { get; set; }

        [StringLength(255)]
        public string? TenSanPhamKhongDau { get; set; }

        public int DonGia { get; set; }
        public int SoLuong { get; set; }

        [StringLength(255)]
        public string? HinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string? MoTa { get; set; }

        public LoaiSanPham? LoaiSanPham { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
    }
}
