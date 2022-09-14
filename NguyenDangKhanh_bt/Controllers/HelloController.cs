using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenDangKhanh.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public String ChaoMung(string ten, int id)
        {
            return HttpUtility.HtmlEncode("Xin chao " + ten + "ID:  " + id);
        }
    
        public ActionResult Index()
        {
            ViewBag.Message = "Liên kết của tôi.";
            return View();
        }
    }
}