using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using onthi2.Models;

namespace onthi2.Controllers
{
    public class NhanViensController : Controller
    {
        private QLLuongDB db = new QLLuongDB();

        // GET: NhanViens
        public ActionResult Index(string sort, string search)
        {
            ViewBag.Luong = sort == "luong" ? "luong_desc" : "luong";
            ViewBag.Phong = sort == "phong" ? "phong_desc" : "phong";
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
                case "phong":
                    nhanvien = nhanvien.OrderBy(s => s.Phong);
                    break;
                case "luong_desc":
                    nhanvien = nhanvien.OrderByDescending(s => s.Luong);
                    break;
                case "phong_desc":
                    nhanvien = nhanvien.OrderByDescending(s => s.Phong);
                    break;
            }
            return View(nhanvien.ToList());
        }

        // GET: NhanViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTen,Phong,Luong")] NhanVien nhanVien)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Mã nhân viên đã tồn tại";
                return View(nhanVien);
            } 
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTen,Phong,Luong")] NhanVien nhanVien)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(nhanVien).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                ViewBag.Error = "Có lỗi khi sửa";
                return View(nhanVien);
            }
            
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            try
            {
                db.NhanViens.Remove(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                ViewBag.Error = "Không xóa được bản ghi này";
                return View("Delete", nhanVien);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
