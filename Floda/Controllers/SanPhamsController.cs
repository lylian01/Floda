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
using Floda.DesignPartern.ProductsProxyParttern;
using Floda.Models;
using PagedList;

namespace Floda.Controllers
{
    public class SanPhamsController : Controller
    {
        private FlodaContext db = new FlodaContext();
        CareTakerForMemento careTaker = new CareTakerForMemento();
        // GET: SanPhams
        public ActionResult Index(int? page)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "User");
            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 8;
            var IsNhapHangs = db.SanPhams.AsNoTracking()
                   .OrderByDescending(x => x.SanPhamID)
                   .Include(s => s.LoaiSanPham);
            PagedList<SanPham> models = new PagedList<SanPham>(IsNhapHangs, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);
        }
        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.LoaiSPID = new SelectList(db.LoaiSanPhams, "LoaiSPID", "TenLoaiSP");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SanPhamID,TenSP,LoaiSPID,SoLuongSP,GiaBan,UrlHinhAnh,MoTa")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                Product product = new ProductProxyParttern(sanPham);
                product.AddProduct();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiSPID = new SelectList(db.LoaiSanPhams, "LoaiSPID", "TenLoaiSP", sanPham.LoaiSPID);
            return View(sanPham);
        }


        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiSPID = new SelectList(db.LoaiSanPhams, "LoaiSPID", "TenLoaiSP", sanPham.LoaiSPID);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "SanPhamID,TenSP,LoaiSPID,SoLuongSP,GiaBan,UrlHinhAnh,MoTa")] SanPham sanPham, string submitButton)
        {
            if (ModelState.IsValid)
            {
                if (submitButton.ToString() == "Save")
                {
                    
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();

                }
                else if (submitButton.ToString() == "Redo")
                {
                    //System.Diagnostics.Debug.WriteLine(careTaker.StoredProduct.SanPhamID.ToString());
                    var memetoSession = Session["Memento"];
                    careTaker.StoredProduct = (Memento)memetoSession;
                    sanPham.RestoreProduct(careTaker.StoredProduct);
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if(submitButton.ToString() == "SaveStage")
                {
                    SanPham sp1 = new SanPham();
                    sp1 = sanPham.ShallowCoppy();
                    sp1 = sanPham.DeepCopy();
                    SanPham sanPhamOlder = db.SanPhams.Find(sp1.SanPhamID);
                    careTaker.StoredProduct = sanPhamOlder.CreateStored(sanPhamOlder);
                    careTaker.SaveMementoToSession(careTaker.StoredProduct);
                }
                return RedirectToAction("Index");
            }
            ViewBag.LoaiSPID = new SelectList(db.LoaiSanPhams, "LoaiSPID", "TenLoaiSP", sanPham.LoaiSPID);
            return View(sanPham);
        }



        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Product productDelete = new ProductProxyParttern(id);
                productDelete.DeleteProduct();
                //db.SanPhams.Remove(sanPham);
                //db.SaveChanges();
            }
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
