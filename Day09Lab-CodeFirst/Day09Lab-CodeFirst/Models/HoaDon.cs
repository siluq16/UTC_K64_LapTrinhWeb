using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_CodeFirst.Models
{
    [Table(name: "HoaDon")]
    public class HoaDon
    {
        [Key]
        public int ID { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime NgayHoaDon { get; set; } = DateTime.Now;
        public DateTime? NgayNhan { get; set; }
        public string HoTenKhachHang { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTriGia { get; set; }
        public bool TrangThai { get; set; } = true;

        public int MaKhachHang { get; set; }
        public KhachHang KhachHang { get; set; }

        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
