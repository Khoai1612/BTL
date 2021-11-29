using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDiem.Models;

namespace QuanLyDiem.Controllers
{
    public class QLGiaoViensController : Controller
    {
        private QuanLyDiemDbContext db = new QuanLyDiemDbContext();
        AutoGenerateKey aukey = new AutoGenerateKey();

        // GET: QLGiaoViens
        public ActionResult Index()
        {
            return View(db.QLGiaoViens.ToList());
        }
        public ActionResult Create()
        {
            var gvID = "";
            var countGV = db.QLGiaoViens.Count();
            if (countGV == 0)
            {
                gvID = "GV001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var MaGV = db.QLGiaoViens.ToList().OrderByDescending(m => m.MaGV).FirstOrDefault().MaGV;
                //sinh MaHS tự dộng
                gvID = aukey.GenerateKey(MaGV);
            }
            ViewBag.MaGV = gvID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(QLGiaoVien gv)

        {
            var countGV = db.QLGiaoViens.Count();
            if (countGV == 0)
            {
                gv.MaGV = "GV001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var MaGV = db.QLGiaoViens.ToList().OrderByDescending(m => m.MaGV).FirstOrDefault().MaGV;
                //sinh MaHS tự dộng
                gv.MaGV = aukey.GenerateKey(MaGV);
            }
            //luu thông tin vao database
            db.QLGiaoViens.Add(gv);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLGiaoVien qLGiaoVien = db.QLGiaoViens.Find(id);
            if (qLGiaoVien == null)
            {
                return HttpNotFound();
            }
            return View(qLGiaoVien);
        }

        // GET: QLGiaoViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLGiaoVien qLGiaoVien = db.QLGiaoViens.Find(id);
            if (qLGiaoVien == null)
            {
                return HttpNotFound();
            }
            return View(qLGiaoVien);
        }

        // POST: QLGiaoViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,TenGV,GioiTinh,NgaySinh,SoDienThoai,DiaChi,AnhGV,MaLop")] QLGiaoVien qLGiaoVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qLGiaoVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qLGiaoVien);
        }

        // GET: QLGiaoViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLGiaoVien qLGiaoVien = db.QLGiaoViens.Find(id);
            if (qLGiaoVien == null)
            {
                return HttpNotFound();
            }
            return View(qLGiaoVien);
        }

        // POST: QLGiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QLGiaoVien qLGiaoVien = db.QLGiaoViens.Find(id);
            db.QLGiaoViens.Remove(qLGiaoVien);
            db.SaveChanges();
            return RedirectToAction("Index");
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
