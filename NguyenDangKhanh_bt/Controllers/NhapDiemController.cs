using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenDangKhanh.Models;

namespace NguyenDangKhanh.Controllers
{
    public class NhapDiemController : Controller
    {
        // GET: NhapDiem
        public ActionResult Index()
        {
            ViewBag.id = "SV001";
            ViewBag.name = "Nguyễn Anh Tuấn";
            ViewData["Marks"] = 9.5;
            return View();
        }
        public ActionResult Cach2(SinhVien sv)
        {
            sv.id = "SV001";
            sv.name = "Nguyễn Anh Tuấn";
            sv.marks = "9.5";
            return View(sv);
        }
    }
}