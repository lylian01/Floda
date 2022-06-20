using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Floda.Models
{
    public class NhapHang
    {
        public NhapHang()
        {
        }
        public int NhapHangID { get; set; }
        public DateTime NgayNhap { get; set; }
        public int  TongTienChi { get; set; }
        public string NoiDung  {get; set; }
    }
}