using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class TinhTrang
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        [StringLength(255)]
        public string? MoTaKhongDau { get; set; }

        public ICollection<DatHang>? DatHang { get; set; }
    }
}
