using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_CodeFirst.Models
{
    [Table(name: "KhachHang")]
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }
        public string MaKhachHang { get; set; }
        public string HoTenKhachHang { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayDangKy { get; set; } = DateTime.Now;
        public bool TrangThai { get; set; } = true;
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}
