using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class DatHang
    {
        public int ID { get; set; }
        public int NguoiDungID { get; set; }
        public int TinhTrangID { get; set; }

        [StringLength(20)]
        public string DienThoaiGiaoHang { get; set; }

        [StringLength(255)]
        public string DiaChiGiaoHang { get; set; }

        public DateTime NgayDatHang { get; set; }

        public NguoiDung? NguoiDung { get; set; }
        public TinhTrang? TinhTrang { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
    }
}
