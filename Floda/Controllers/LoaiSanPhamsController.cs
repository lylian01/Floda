using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Floda.DAL;
using Floda.DesignPartern;
using Floda.Models;
using PagedList;

namespace Floda.Controllers
{
    public class LoaiSanPhamsController : Controller
    {
        private FlodaContext db = new FlodaContext();

        // GET: LoaiSanPhams
        public ActionResult Index(int? page)
        {
            
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "User");
            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 8;
            var IsNhapHangs = db.LoaiSanPhams.AsNoTracking()
                   .OrderByDescending(x => x.LoaiSPID);
            PagedList<LoaiSanPham> models = new PagedList<LoaiSanPham>(IsNhapHangs, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);
        }

        // GET: LoaiSanPhams/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }
*/
        // GET: LoaiSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoaiSPID,TenLoaiSP")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                FlowerCategorySingleton flowerCategorySingleton = FlowerCategorySingleton.GetInstance();
                flowerCategorySingleton.AddCategotyFlower(loaiSanPham);
                return RedirectToAction("Index");
            }

            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoaiSPID,TenLoaiSP")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                FlowerCategorySingleton flowerCategorySingleton = FlowerCategorySingleton.GetInstance();
                flowerCategorySingleton.EditCategotyFlower(loaiSanPham);
                return RedirectToAction("Index");
            }
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowerCategorySingleton flowerCategorySingleton = FlowerCategorySingleton.GetInstance();
            flowerCategorySingleton.RemoveCategotyFlower(id);          
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
