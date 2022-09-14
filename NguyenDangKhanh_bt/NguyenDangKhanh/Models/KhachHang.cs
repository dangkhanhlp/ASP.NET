using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenDangKhanh.Models
{
    public class KhachHang
    {
        public string HoTen { get; set; }

        public string UuTien { get; set; }
        public string LoaiDien { get; set; }
        public int SoMoi { get; set; }
        public int SoCu { get; set; }
    }
}