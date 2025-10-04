using System;
using System.Collections.Generic;

namespace DBCDay07.Models;

public partial class TblChatlieu
{
    public string MaChatLieu { get; set; } = null!;

    public string TenChatLieu { get; set; } = null!;

    public virtual ICollection<TblHang> TblHangs { get; set; } = new List<TblHang>();
}
