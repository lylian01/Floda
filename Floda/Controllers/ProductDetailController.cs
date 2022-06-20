using Floda.DAL;
using Floda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Floda.Controllers
{
    public class ProductDetailController : Controller
    {
        private FlodaContext db = new FlodaContext();

        // GET: ProductDetail/Details/5
      
        public ActionResult Index(int? id)
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
            /* ViewBag.Top = db.SanPhams.Where(p => p.SanPhamID > 0).OrderByDescending(p => p.Views).Take(4).ToList();*/

            return View(sanPham);
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
