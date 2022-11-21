using Floda.DesignPartern;
using Floda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Floda.Models
{
    public class SanPham
    {
        public SanPham() { }
        [Key]
        public int SanPhamID { get; set; }
        [StringLength(1000, MinimumLength = 10)]
        public string TenSP { get; set; }
        public int LoaiSPID { get; set; }
        [ForeignKey("LoaiSPID")]
        public LoaiSanPham LoaiSanPham { get; set; }
        public Nullable<int> SoLuongSP { get; set; }
        public Nullable<int> GiaBan { get; set; }
        public string UrlHinhAnh { get; set; }
        public string MoTa { get; set; }

        //Create Originator for Memento Pattern
        public Memento CreateStored(SanPham sp)
        {
            return new Memento(sp.SanPhamID, sp.TenSP, sp.LoaiSPID, sp.SoLuongSP, sp.GiaBan, sp.UrlHinhAnh, sp.MoTa);
        }
        public void RestoreProduct(Memento spMemento)
        {
            this.SanPhamID = spMemento.SanPhamID;
            this.TenSP = spMemento.TenSP;
            this.LoaiSPID = spMemento.LoaiSPID;
            this.SoLuongSP = spMemento.SoLuongSP;
            this.GiaBan = spMemento.GiaBan;
            this.UrlHinhAnh = spMemento.UrlHinhAnh;
            this.MoTa = spMemento.MoTa;
        }
        public virtual ICollection<ChiTietHoaDon> HoaDons { get; set; }
    }
}