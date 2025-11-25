using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBH.Models;

public partial class HangHoa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaHang { get; set; }
    [Required]
    public int MaLoai { get; set; }
    [Required]
    public string TenHang { get; set; } = null!;
    [Required]
    [Range(1000,5000, ErrorMessage = "Phải là số từ 1000 đến 5000")]
    public decimal? Gia { get; set; }
    [Required]
    public string? Anh { get; set; }

    public virtual LoaiHang? MaLoaiNavigation { get; set; } = null!;
}
