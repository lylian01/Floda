using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Floda.Models
{
    public class KhachHang
    {
        public KhachHang()
        {
        }

        public KhachHang(string tenKH, string diaChi, string dienThoai, string username, string password) : this(tenKH, diaChi)
        {
            DienThoai = dienThoai;
            Username = username;
            Password = password;
        }

        public KhachHang(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Key]
        public int KhachHangID { get; set; }

        public string TenKH { get; set; }

        public string DiaChi { get; set; }

        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Username Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }



        public ICollection<HoaDon> HoaDons { get; set; }
    }
}