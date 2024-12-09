using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class LoaiSanPham
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string TenLoaiSP { get; set; }

        [StringLength(255)]
        public string? TenLoaiSPKhongDau { get; set; }

        public ICollection<SanPham>? SanPham { get; set; }
    }
}
