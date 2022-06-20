using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Floda.Models
{
    public class HoaDon
    {
        public HoaDon() { }

        [Key]
        public int HoaDonID { get; set; }

        public int KhachHangID { get; set; }
        [ForeignKey("KhachHangID")]
        public KhachHang KhachHang { get; set; }

        public DateTime Ngay { get; set; }

        public int TongTien { get; set; }

        public virtual ICollection<ChiTietHoaDon> SanPhams { get; set; }
    }
}