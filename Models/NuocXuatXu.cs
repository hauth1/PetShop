using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class NuocXuatXu
    {
        [DisplayName("Mã nước xuất xứ")]
        public int ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Tên nước xuất xứ không được bỏ trống.")]
        [DisplayName("Tên nước xuất xứ")]
        public string TenNuocXuatXu { get; set; }

        [StringLength(255)]
        [DisplayName("Tên nước xuất xứ không dấu")]
        public string? TenNuocXuatXuKhongDau { get; set; }

        public ICollection<ThuCung>? ThuCung { get; set; }
    }
}
