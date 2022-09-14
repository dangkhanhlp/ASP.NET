using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onthi2.Models;

namespace onthi2.Controllers
{
    public class NhanVienController : Controller
    {
        QLLuongDB db = new QLLuongDB();
        // GET: NhanVien
        public ActionResult Index(string sort, string search)
        {
            ViewBag.Luong = sort == "luong"? "luong_desc": "luong";
            var nhanvien = db.NhanViens.Select(p => p);
            if(!String.IsNullOrEmpty(search))
            {
                nhanvien = db.NhanViens.Where(s => s.HoTen.Contains(search));
            }
            switch(sort)
            {
                case "luong":
                    nhanvien = nhanvien.OrderBy(s => s.Luong);
                    break;
                case "luong_desc":
                    nhanvien = nhanvien.OrderByDescending(s => s.Luong);
                    break;
            }    
            return View(nhanvien.ToList());
        }
        public ActionResult ChiTiet(string id)
        {
            var nhanvien = db.NhanViens.First(s => s.MaNV == id);
            return View(nhanvien);
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
                ViewBag.loi1 = "Mã nhân viên không được để trống";
            }
            else if (String.IsNullOrEmpty(ten))
            {
                ViewBag.loi2 = "Họ tên nhân viên không được để trống";
            }
            else if (String.IsNullOrEmpty(phong))
            {
                ViewBag.loi3 = "Phòng không được để trống";
            }
            else if (String.IsNullOrEmpty(luong))
            {
                ViewBag.loi4 = "Lương không được để trống";
            }
            else
            {
                nv.MaNV = ma;
                nv.HoTen= ten;
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
            var nhanvien = db.NhanViens.First(s => s.MaNV == id);
            return View(nhanvien);
        }
        [HttpPost]
        public ActionResult Xoa(string id, FormCollection data)
        {
            var nhanvien = db.NhanViens.First(s => s.MaNV == id);

            db.NhanViens.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Sua(string id)
        {
            var nhanvien = db.NhanViens.First(s => s.MaNV == id);
            return View(nhanvien);
        }
        [HttpPost]
        public ActionResult Sua(string id, FormCollection data)
        {
            var nhanvien = db.NhanViens.First(s => s.MaNV == id);

            var ten = data["HoTen"];
            var phong = data["Phong"];
            var luong = data["Luong"];

            if (String.IsNullOrEmpty(ten))
            {
                ViewBag.loi1 = "Họ tên nhân viên không được để trống";
            }
            else if (String.IsNullOrEmpty(phong))
            {
                ViewBag.loi2 = "Phòng không được để trống";
            }
            else if (String.IsNullOrEmpty(luong))
            {
                ViewBag.loi3 = "Lương không được để trống";
            }
            else
            {
                nhanvien.HoTen = ten;
                nhanvien.Phong = phong;
                nhanvien.Luong = Convert.ToDouble(luong);

                UpdateModel(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Sua(id);
        }
    }
}