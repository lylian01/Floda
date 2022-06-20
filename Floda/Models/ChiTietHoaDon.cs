using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Floda.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int ChiTietHoaDonID { get; set; }

        public int SanPhamID { get; set; }
        [ForeignKey("SanPhamID")]
        public SanPham SanPham { get; set; }

        public int HoaDonID { get; set; }
        [ForeignKey("HoaDonID")]
        public HoaDon HoaDon { get; set; }

        public int SoLuong { get; set; }

        public int ThanhTien { get; set; }
    }
}