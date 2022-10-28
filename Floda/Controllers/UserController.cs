using Floda.DAL;
using Floda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Floda.Controllers
{
    public class UserController : Controller
    {
        private FlodaContext db = new FlodaContext();
        // GET: User
        public ActionResult Dangky()
        {
            return View();
        }

        // ĐĂNG KÝ PHƯƠNG THỨC POST
        [HttpPost]
        public ActionResult Dangky(KhachHang khachang)
        {
            try
            {
                // Thêm người dùng  mới
                db.KhachHangs.Add(khachang);
                // Lưu lại vào cơ sở dữ liệu
                db.SaveChanges();
                // Nếu dữ liệu đúng thì trả về trang đăng nhập
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Dangnhap");
                }
                return View("Dangky");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dangnhap()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Dangnhap(string Username, string Password)
        {
           string usr = Username;
           string pwp = Password;

            var islogin = db.KhachHangs.SingleOrDefault(x => x.Username.Equals(usr) && x.Password.Equals(pwp));

            if (islogin != null)
            {
                if (Username == "Admin@gmail.com")
                {
                   
                    Session["user"] = islogin;
                   
                    return RedirectToAction("Index", "NhapHangs");
                }
                else
                {
                    Session["user"] = islogin;
                    return RedirectToAction("ShowToCart", "ShoppingCart");
                }
            }
            else
            {
                ViewBag.Fail = "Đăng nhập thất bại";
                return View("Dangnhap");
            }

        }
        public ActionResult DangXuat()
        {
            
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
        /*//create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }*/


    }
}