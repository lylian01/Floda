using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Floda.Models;

namespace Floda.DesignPartern
{
    public class Memento
    {
        //SanPhamID,TenSP,LoaiSPID,SoLuongSP,GiaBan,UrlHinhAnh,MoTa
        public int SanPhamID;
        public string TenSP;
        public int LoaiSPID;
        public Nullable<int> SoLuongSP;
        public Nullable<int> GiaBan;
        public string UrlHinhAnh;
        public string MoTa;

        public Memento()
        {
        }

        public Memento(int sanPhamID, string tenSP, int loaiSPID, int? soLuongSP, int? giaBan, string urlHinhAnh, string moTa)
        {
            this.SanPhamID = sanPhamID;
            this.TenSP = tenSP;
            this.LoaiSPID = loaiSPID;
            this.SoLuongSP = soLuongSP;
            this.GiaBan = giaBan;
            this.UrlHinhAnh = urlHinhAnh;
            this.MoTa = moTa;
        }
        
    }
}