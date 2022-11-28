using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Floda.Models
{
    public class LoaiSanPham
    {
        public LoaiSanPham(int loaiSPID)
        {
            this.LoaiSPID = loaiSPID;
        }
        public LoaiSanPham()
        { }

        [Key]
        public int LoaiSPID { get; set; }
        public string TenLoaiSP { get; set; }

        public ICollection<SanPham> SanPhams { get; set; }
    }
}