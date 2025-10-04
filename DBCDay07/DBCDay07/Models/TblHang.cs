using System;
using System.Collections.Generic;

namespace DBCDay07.Models;

public partial class TblHang
{
    public string MaHang { get; set; } = null!;

    public string TenHang { get; set; } = null!;

    public string? MaChatLieu { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGiaNhap { get; set; }

    public decimal? DonGiaBan { get; set; }

    public string? Anh { get; set; }

    public string? GhiChu { get; set; }

    public virtual TblChatlieu? MaChatLieuNavigation { get; set; }

    public virtual ICollection<TblChitietHdban> TblChitietHdbans { get; set; } = new List<TblChitietHdban>();
}
