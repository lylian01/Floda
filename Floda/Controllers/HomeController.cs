using Floda.DAL;
using Floda.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Floda.Controllers
{
    public class HomeController : Controller
    {
        private FlodaContext db = new FlodaContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search()
        {
            return View(db.SanPhams.ToList());
        }

        public ActionResult HoaCuoi(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 8;
            var IsSanPhams = db.SanPhams.AsNoTracking()
                    .OrderByDescending(x => x.SanPhamID).Where(x => x.LoaiSPID == 1).ToList();
            PagedList<SanPham> models = new PagedList<SanPham>(IsSanPhams, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(models);

        }
        public ActionResult HoaChucMung(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 8;

            var IsSanPhams = db.SanPhams.AsNoTracking()
                    .OrderByDescending(x => x.SanPhamID).Where(x => x.LoaiSPID == 2).ToList();
            PagedList<SanPham> models = new PagedList<SanPham>(IsSanPhams, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);


        }
        public ActionResult HoaTotNghiep(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 8;
            var IsSanPhams = db.SanPhams.AsNoTracking()
                    .OrderByDescending(x => x.SanPhamID).Where(x => x.LoaiSPID == 3).ToList();
            PagedList<SanPham> models = new PagedList<SanPham>(IsSanPhams, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);


        }
        public ActionResult HoaKhaiTruong(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 8;
            var IsSanPhams = db.SanPhams.AsNoTracking()
                    .OrderByDescending(x => x.SanPhamID).Where(x => x.LoaiSPID == 4).ToList();
            PagedList<SanPham> models = new PagedList<SanPham>(IsSanPhams, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);


        }

    }
}