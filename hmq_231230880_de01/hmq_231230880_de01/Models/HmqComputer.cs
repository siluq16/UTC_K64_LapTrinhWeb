using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hmq_231230880_de01.Models;

public partial class HmqComputer
{
    public int HmqComId { get; set; }

    [Required(ErrorMessage = "Tên khoogn được bỏ trống")]
    public string? HmqComName { get; set; }

    [Range(100, 5000, ErrorMessage = "Giá phải là số trong giới hạn 100 dến 5000")]
    public decimal? HmqComPrice { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [RegularExpression(@".*\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên file ảnh có đuỏi .jpg, .png, or .gif")]
    public string? HmqComImage { get; set; }

    public bool? HmqComStatus { get; set; }
}
