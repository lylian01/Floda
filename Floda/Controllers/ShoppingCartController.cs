using Floda.DAL;
using Floda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Floda.Controllers
{
    public class ShoppingCartController : Controller
    {
        private FlodaContext db = new FlodaContext();
        private ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var sanpham = db.SanPhams.SingleOrDefault(x => x.SanPhamID == id);
            if (sanpham != null)
            {
                GetCart().Add(sanpham);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("NullCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult NullCart()
        {
            return View();
        }

        public ActionResult UpdateQuantityInCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int IDSanPham = int.Parse(form["ID_SanPham"]);
            int soluongSP = int.Parse(form["SoLuong_SP"]);
            cart.UpdateSoluongSanphamCart(IDSanPham, soluongSP);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult RemoveProductInCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveSanpham(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }


        public ActionResult CreateOrder()
        {
            Cart cart = Session["Cart"] as Cart;
            var u = Session["user"] as Floda.Models.KhachHang;

            try 
            {
                
                HoaDon hoaDon = new HoaDon();

                hoaDon.Ngay = DateTime.Now;
                hoaDon.KhachHangID = u.KhachHangID;
                hoaDon.TongTien = cart.TotalPrice();

                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                foreach (var item in cart.Items)
                {
                    ChiTietHoaDon chiTiet = new ChiTietHoaDon();
                    chiTiet.HoaDonID = hoaDon.HoaDonID;

                    chiTiet.SanPhamID = item.shoppingSanpham.SanPhamID;
                    chiTiet.SoLuong = item.shoppingSoluong;
                    chiTiet.ThanhTien = (int)(item.shoppingSanpham.GiaBan * item.shoppingSoluong);

                    db.ChiTietHoaDons.Add(chiTiet);
                    db.SaveChanges();
                }

                db.SaveChanges();

                    cart.RemoveAll();
                    return RedirectToAction("Done", "ShoppingCart");
                
                
            }
            catch 
            {
                
                return RedirectToAction("Payment", "ShoppingCart");
            }

        }
        public ActionResult Done()
        {
            return View();
        }


        //[Authorize]
        public ActionResult Payment()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "User");
            }

            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return View(cart);
        }

        public PartialViewResult BagCart()
        {
            int tongSP = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                tongSP = cart.TotalSoluong();
            }
            ViewBag.infoCart = tongSP;
            return PartialView("BagCart");
        }
    }
}