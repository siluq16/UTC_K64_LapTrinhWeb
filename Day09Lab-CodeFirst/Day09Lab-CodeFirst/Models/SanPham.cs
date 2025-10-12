using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_CodeFirst.Models
{
    [Table(name: "SanPham")]
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public bool TrangThai { get; set; } = true;
        public int MaLoai { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
