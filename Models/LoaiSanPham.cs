using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class LoaiSanPham
    {
        [DisplayName("Mã loại")]
        public int ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Tên loại không được bỏ trống.")]
        [DisplayName("Tên loại")]
        public string TenLoaiSP { get; set; }

        [StringLength(255)]
        [DisplayName("Tên loại không dấu")]
        public string? TenLoaiSPKhongDau { get; set; }

        public ICollection<SanPham>? SanPham { get; set; }
    }
}
