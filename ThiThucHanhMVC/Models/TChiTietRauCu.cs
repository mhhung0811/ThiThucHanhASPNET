using System;
using System.Collections.Generic;

namespace ThiThucHanhMVC.Models;

public partial class TChiTietRauCu
{
    public string MaChiTietRauCu { get; set; } = null!;

    public string? MaRauCu { get; set; }

    public DateOnly? NgayThuHoach { get; set; }

    public string? MoTaChiTiet { get; set; }

    public int? ThoiGianBaoQuan { get; set; }

    public string? TrangThai { get; set; }

    public string? HinhAnh { get; set; }
}
