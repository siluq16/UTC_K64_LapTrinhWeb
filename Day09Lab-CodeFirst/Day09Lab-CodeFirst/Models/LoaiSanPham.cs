using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_CodeFirst.Models
{
    [Table(name: "LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        public int ID { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
