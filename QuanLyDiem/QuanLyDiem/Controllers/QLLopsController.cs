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
    public class QLLopsController : Controller
    {
        private QuanLyDiemDbContext db = new QuanLyDiemDbContext();
        AutoGenerateKey aukey = new AutoGenerateKey();

        // GET: QLLops
        public ActionResult Index()
        {
            return View(db.QLLops.ToList());
        }
        public ActionResult Create()
        {
            var lopID = "";
            var countlop = db.QLLops.Count();
            if (countlop == 0)
            {
                lopID = "L001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var Malop = db.QLLops.ToList().OrderByDescending(m => m.MaLop).FirstOrDefault().MaLop;
                //sinh MaHS tự dộng
                lopID = aukey.GenerateKey(Malop);
            }
            ViewBag.Malop = lopID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(QLLop lop)

        {
            var countlop = db.QLLops.Count();
            if (countlop == 0)
            {
                lop.MaLop = "L001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var Malop = db.QLLops.ToList().OrderByDescending(m => m.MaLop).FirstOrDefault().MaLop;
                //sinh MaHS tự dộng
                lop.MaLop = aukey.GenerateKey(Malop);
            }
            //luu thông tin vao database
            db.QLLops.Add(lop);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: QLLops/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLLop qLLop = db.QLLops.Find(id);
            if (qLLop == null)
            {
                return HttpNotFound();
            }
            return View(qLLop);
        }


        // GET: QLLops/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLLop qLLop = db.QLLops.Find(id);
            if (qLLop == null)
            {
                return HttpNotFound();
            }
            return View(qLLop);
        }

        // POST: QLLops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop,NienKhoa,SiSo,GhiChu")] QLLop qLLop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qLLop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qLLop);
        }

        // GET: QLLops/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLLop qLLop = db.QLLops.Find(id);
            if (qLLop == null)
            {
                return HttpNotFound();
            }
            return View(qLLop);
        }

        // POST: QLLops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QLLop qLLop = db.QLLops.Find(id);
            db.QLLops.Remove(qLLop);
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
