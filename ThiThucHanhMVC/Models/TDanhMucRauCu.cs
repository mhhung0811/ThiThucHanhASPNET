using System;
using System.Collections.Generic;

namespace ThiThucHanhMVC.Models;

public partial class TDanhMucRauCu
{
    public string MaRauCu { get; set; } = null!;

    public string? TenRauCu { get; set; }

    public decimal? DonGia { get; set; }

    public string? NguonGoc { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public string? MaLoaiRauCu { get; set; }
}
