using System;
using System.Collections.Generic;

namespace ThiThucHanhMVC.Models;

public partial class TKhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string? Username { get; set; }

    public string? TenKhachHang { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public byte? LoaiKhachHang { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? GhiChu { get; set; }
}
