using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenDangKhanh.Models;

namespace NguyenDangKhanh.Controllers
{
    public class Bai2Controller : Controller
    {
        // GET: Bai2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Regis(Person p)
        {
            return View(p);
        }
    }
}