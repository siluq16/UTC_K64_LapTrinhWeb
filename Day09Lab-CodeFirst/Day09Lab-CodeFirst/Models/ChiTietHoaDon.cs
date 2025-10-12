using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_CodeFirst.Models
{
    [Table(name: "ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuongMua { get; set; }
        public decimal DonGiaMua { get; set; }
        public decimal ThanhTien => SoLuongMua * DonGiaMua;
        public bool TrangThai { get; set; } = true;

        public HoaDon HoaDon { get; set; }
        public SanPham SanPham { get; set; }
    }
}
