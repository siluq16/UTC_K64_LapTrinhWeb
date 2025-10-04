using System;
using System.Collections.Generic;

namespace DBCDay07.Models;

public partial class TblHdban
{
    public string MaHdban { get; set; } = null!;

    public string? MaNhanvien { get; set; }

    public DateOnly? NgayBan { get; set; }

    public string? MaKhach { get; set; }

    public decimal? TongTien { get; set; }

    public virtual TblKhach? MaKhachNavigation { get; set; }

    public virtual TblNhanvien? MaNhanvienNavigation { get; set; }

    public virtual ICollection<TblChitietHdban> TblChitietHdbans { get; set; } = new List<TblChitietHdban>();
}
