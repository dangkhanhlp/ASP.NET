using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenDangKhanh_189.Models;

namespace NguyenDangKhanh_189.Controllers
{
    public class CaculateController : Controller
    {
        // GET: Caculate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TinhToan(Tinh tinh)
        {
            double soA = tinh.a;
            double soB = tinh.b;
            string pt = tinh.pheptinh;

            if (pt.Equals("+"))
            {
                ViewBag.kq = "a "+ pt + " b " + " = " + (soA + soB);
            }
            if (pt.Equals("-"))
            {
                ViewBag.kq = "a " + pt + " b " + " = " + (soA - soB);
            }
            if (pt.Equals("*"))
            {
                ViewBag.kq = " a " + pt + " b " + " = " + (soA * soB);
            }
            if (pt.Equals("/"))
            {
                ViewBag.kq = " a " + pt + " b " + " = " + (soA / soB);
            }
            return View();
        }
    }
}