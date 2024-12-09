using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class NuocXuatXu
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string TenNuocXuatXu { get; set; }

        [StringLength(255)]
        public string? TenNuocXuatXuKhongDau { get; set; }

        public ICollection<ThuCung>? ThuCung { get; set; }
    }
}
