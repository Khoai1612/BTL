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
    public class DiemHocSinhsController : Controller
    {
        private QuanLyDiemDbContext db = new QuanLyDiemDbContext();

        // GET: DiemHocSinhs
        public ActionResult Index()
        {
            return View(db.DiemHocSinhs.ToList());
        }

        // GET: DiemHocSinhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            if (diemHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(diemHocSinh);
        }

        // GET: DiemHocSinhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiemHocSinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiemMieng,Diem15Phut,Diem1Tiet,DiemHK,DiemTBHK,GhiChu")] DiemHocSinh diemHocSinh)
        {
            if (ModelState.IsValid)
            {
                db.DiemHocSinhs.Add(diemHocSinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diemHocSinh);
        }

        // GET: DiemHocSinhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            if (diemHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(diemHocSinh);
        }

        // POST: DiemHocSinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiemMieng,Diem15Phut,Diem1Tiet,DiemHK,DiemTBHK,GhiChu")] DiemHocSinh diemHocSinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemHocSinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diemHocSinh);
        }

        // GET: DiemHocSinhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            if (diemHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(diemHocSinh);
        }

        // POST: DiemHocSinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            db.DiemHocSinhs.Remove(diemHocSinh);
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
