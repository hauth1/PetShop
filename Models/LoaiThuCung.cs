using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class LoaiThuCung
    {
        [DisplayName("Mã loại thú cưng")]
        public int ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Tên loại thú cưng không được bỏ trống.")]
        [DisplayName("Tên loại thú cưng")]
        public string TenLoaiTC { get; set; }

        [StringLength(255)]
        [DisplayName("Tên loại thú cưng không dấu")]
        public string? TenLoaiTCKhongDau { get; set; }

        public ICollection<ThuCung>? ThuCung { get; set; }
    }
}
