using System;
using System.Collections.Generic;

namespace DBCDay07.Models;

public partial class TblNhanvien
{
    public string MaNhanvien { get; set; } = null!;

    public string TenNhanvien { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public virtual ICollection<TblHdban> TblHdbans { get; set; } = new List<TblHdban>();
}
