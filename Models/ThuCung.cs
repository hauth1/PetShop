using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PetShop.Models
{
    public class ThuCung
    {
        [DisplayName("Mã Thú Cưng")]
        public int ID { get; set; }

        [DisplayName("Nước xuất xứ")]
        [Required(ErrorMessage = "Nước xuất xứ không được bỏ trống.")]
        public int TenNuocXuatXuID { get; set; }

        [DisplayName("Loại thú cưng")]
        [Required(ErrorMessage = "Loại thú cưng không được bỏ trống.")]
        public int LoaiThuCungID { get; set; }

        [StringLength(255)]
        [DisplayName("Tên thú cưng")]
        [Required(ErrorMessage = "Tên thú cưng không được bỏ trống.")]
        public string TenThuCung { get; set; }

        [StringLength(255)]
        [DisplayName("Tên thú cưng không dấu")]
        public string? TenThuCungKhongDau { get; set; }

        [StringLength(255)]
        [DisplayName("Giống")]
        public string Giong { get; set; }

        [DisplayName("Tuổi")]
        public int Tuoi { get; set; }

        [StringLength(255)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(255)]
        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }

        [StringLength(255)]
        [DisplayName("Tình trạng sức khỏe")]
        public string TinhTrangSucKhoe { get; set; }

        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Đơn giá không được bỏ trống.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int DonGia { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int SoLuong { get; set; }

        [StringLength(255)]
        [DisplayName("Hình ảnh")]
        public string? HinhAnh { get; set; }

        [NotMapped]
        [Display(Name = "Hình ảnh sản phẩm")]
        public IFormFile? DuLieuHinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả chi tiết")]
        [DataType(DataType.MultilineText)]
        public string? MoTa { get; set; }

        public NuocXuatXu? NuocXuatXu { get; set; }
        public LoaiThuCung? LoaiThuCung { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
    }
}
