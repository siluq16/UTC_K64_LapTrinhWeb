using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_CodeFirst.Models
{
    [Table(name: "QuanTri")]
    public class QuanTri
    {
        [Key]
        public int ID { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; } = true;
    }
}
