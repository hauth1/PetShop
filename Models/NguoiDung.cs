using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class NguoiDung
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string HoVaTen { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string? DienThoai { get; set; }

        [StringLength(255)]
        public string? DiaChi { get; set; }

        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [StringLength(255)]
        public string MatKhau { get; set; }

        public bool Quyen { get; set; }

        public ICollection<DatHang>? DatHang { get; set; }
    }
}
