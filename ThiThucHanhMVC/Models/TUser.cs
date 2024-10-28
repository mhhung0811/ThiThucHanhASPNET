using System;
using System.Collections.Generic;

namespace ThiThucHanhMVC.Models;

public partial class TUser
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte? LoaiUser { get; set; }
}
