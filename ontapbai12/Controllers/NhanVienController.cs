using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ontapbai12.Models;

namespace ontapbai12.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        QLLuongDB db = new QLLuongDB();
        public ActionResult Index()
        {
            var query = db.NhanViens.Select(p => p);
            return View(query);
        }
        public ActionResult ChiTiet(string id)
        {
            var query = db.NhanViens.Where(m => m.MaNV == id).First();
            return View(query);
        }
        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(FormCollection data, NhanVien nv)
        {
            var ma = data["MaNV"];
            var ten = data["HoTen"];
            var phong = data["Phong"];
            var luong = data["Luong"];
            if(String.IsNullOrEmpty(ma))
            {
                ViewBag.Loi1 = "Mã nhân viên không được để trống";
            }
            else if (String.IsNullOrEmpty(ten))
            {
                ViewBag.Loi2 = "Tên nhân viên không được để trống";
            }
            else if (String.IsNullOrEmpty(phong))
            {
                ViewBag.Loi3 = "Phòng không được để trống";
            }
            else if (String.IsNullOrEmpty(luong))
            {
                ViewBag.Loi4 = "Lương không được để trống";
            }
            else
            {
                nv.MaNV = ma;
                nv.HoTen = ten;
                nv.Phong = phong;
                nv.Luong = Convert.ToDouble(luong);

                db.NhanViens.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Them();
        }
        [HttpGet]
        public ActionResult Xoa(string id)
        {
            var query = db.NhanViens.First(m => m.MaNV == id);
            return View(query);
        }
        [HttpPost]
        public ActionResult Xoa(string id, FormCollection data)
        {
            var query = db.NhanViens.Where(m => m.MaNV == id).First();
            db.NhanViens.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Sua(string id)
        {
            var query = db.NhanViens.First(m => m.MaNV == id);
            return View(query);
        }
        [HttpPost]
        public ActionResult Sua(string id, FormCollection data)
        {
            var nv = db.NhanViens.First(m => m.MaNV == id);

            var ten = data["HoTen"];
            var phong = data["Phong"];
            var luong = data["Luong"];
            if(String.IsNullOrEmpty(ten))
            {
                ViewBag.Loi1 = "Họ tên không được để trống";
            }
            else if (String.IsNullOrEmpty(phong))
            {
                ViewBag.Loi1 = "Phòng không được để trống";
            }
            else if (String.IsNullOrEmpty(luong))
            {
                ViewBag.Loi1 = "Lương không được để trống";
            }
            else
            {
                nv.HoTen = ten;
                nv.Phong = phong;
                nv.Luong = Convert.ToDouble(luong);
                UpdateModel(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Sua(id);
        }
    }
}