using System;
using System.Collections.Generic;

namespace DBCDay07.Models;

public partial class TblChitietHdban
{
    public string MaHdban { get; set; } = null!;

    public string MaHang { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? GiaMua { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual TblHang MaHangNavigation { get; set; } = null!;

    public virtual TblHdban MaHdbanNavigation { get; set; } = null!;
}
