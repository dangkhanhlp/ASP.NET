using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenDangKhanh_189.Models;
namespace NguyenDangKhanh_189.Controllers
{
    public class NhapDiemController : Controller
    {
        // GET: NhapDiem
        /*        public ActionResult Xuly(FormCollection data)
                {

                    string Ma = data["Id"];
                    string Ten = data["Name"];
                    double Diem = Convert.ToDouble(data["Marks"]);
                    ViewBag.ma = Ma;
                    ViewBag.ten = Ten;
                    ViewBag.diem = Diem;
                    return View();
                }*/
        /*     public ActionResult Xuly()
             {
                 string Ma = Request["Id"];
                 string Ten = Request["Name"];
                 double Diem = Convert.ToDouble(Request["Marks"]);
                 ViewBag.ma = Ma;
                 ViewBag.ten = Ten;
                 ViewBag.diem = Diem;
                 return View();
             }*/
        /*        public ActionResult Xuly(string Id="", string Name="", double Marks = 0)
                {
                    ViewBag.ma = Id;
                    ViewBag.ten = Name;
                    ViewBag.diem = Marks;
                    return View();
                }*/
        public ActionResult Xuly(SinhVien sv)
        {
            ViewBag.ma = sv.Id;
            ViewBag.ten = sv.Name;
            ViewBag.diem = sv.Marks;
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}