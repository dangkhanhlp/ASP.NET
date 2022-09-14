using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onthi1.Models;

namespace onthi1.Controllers
{
    public class NhanVienController : Controller
    {
        QLLuongDB db = new QLLuongDB();
        // GET: NhanVien
      // [HttpGet]
        public ActionResult Index(string sortOrder, string search)
        {
            ViewBag.SapTheoLuong = sortOrder == "luong" ? "luong_desc" : "luong";
            ViewBag.Phong = sortOrder == "phong" ? "phong_desc" : "phong";
            var nhanviens = db.NhanViens.Select(p => p);

            if (!String.IsNullOrEmpty(search))
            {
                nhanviens = nhanviens.Where(p => p.HoTen.Contains(search));
            }
            switch (sortOrder)
            {
                case "luong":
                    nhanviens = nhanviens.OrderBy(s => s.Luong);
                    break;
                case "luong_desc":
                    nhanviens = nhanviens.OrderByDescending(s => s.Luong);
                    break;
                case "phong":
                    nhanviens = nhanviens.OrderBy(s => s.Phong);
                    break;
                case "phong_desc":
                    nhanviens = nhanviens.OrderByDescending(s => s.Phong);
                    break;
            }
            return View(nhanviens.ToList());
        }
        /*        public ActionResult Index()
                {
                    var query = db.NhanViens.Select(p => p);
                    return View(query);
                }*/
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
        public ActionResult Them(FormCollection data, NhanVien nv, string x)
        {
            var ma = data["MaNV"];
            var ten = data["HoTen"];
            var phong = data["Phong"];
            var luong = data["Luong"];

            var query = db.NhanViens.Where(m => m.MaNV == x);
            if(nv.MaNV == x)
            {
                ViewBag.loi1 = "Mã trùng";
            }

            if (String.IsNullOrEmpty(ma))
            {
                ViewBag.loi1 = "Mã nhân viên không được để trống";
            }
            else if (String.IsNullOrEmpty(ten))
            {
                ViewBag.loi2 = "Tên nhân viên không được để trống";
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
            var query = db.NhanViens.First(m => m.MaNV == id);
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
            var query = db.NhanViens.First(m => m.MaNV == id);
            var ten = data["HoTen"];
            var phong = data["Phong"];
            var luong = data["Luong"];
            if (String.IsNullOrEmpty(ten))
            {
                ViewBag.loi1 = "Tên nhân viên không được để trống";
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
                query.HoTen = ten;
                query.Phong = phong;
                query.Luong = Convert.ToDouble(luong);

                UpdateModel(query);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Sua(id);
        }
    }
}