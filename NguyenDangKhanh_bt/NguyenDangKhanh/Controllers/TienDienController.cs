using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenDangKhanh.Models;

namespace NguyenDangKhanh.Controllers
{
    public class TienDienController : Controller
    {
        // GET: TienDien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tinh(KhachHang kh)
        {
            string ht = kh.HoTen;
            string ld = kh.LoaiDien;
            int cu = kh.SoCu;
            int moi = kh.SoMoi;
            int sodien = moi - cu;
            double tien = 0;

            if(sodien <= 100)
            {
                tien = 100 * 2000;
            }
            else
                if (sodien > 100 && sodien <= 150)
                    tien = 100 * 2000 + (sodien - 100) * 2500;
            else
                if (sodien > 150 && sodien <= 200)
                {
                    tien = 100 * 2000 + 50 * 2500 + (sodien - 150) * 3000;
                }
            else
                if (sodien > 200)
                {
                    tien = 100 * 2000 + 50 * 2500 + 50 * 3000 + (sodien - 200) * 4000;
                }

            if(kh.UuTien == "on")
            {
                tien = tien * 0.9;
            }
            if(ld == "2")
            {
                tien = tien* 1.2 ;
            }

            if (ld == "3")
            {
                tien = tien * 1.3 ;
            }
            ViewBag.chuho = ht;
            ViewBag.tien = tien;
            ViewBag.sodien = sodien;
            return View();
        }
    }
}