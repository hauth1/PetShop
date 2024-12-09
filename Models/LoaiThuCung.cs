using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class LoaiThuCung
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string TenLoaiTC { get; set; }

        [StringLength(255)]
        public string? TenLoaiTCKhongDau { get; set; }

        public ICollection<ThuCung>? ThuCung { get; set; }
    }
}
