using Floda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Floda.DAL
{
    public class FlodaContext : DbContext
    {
        public FlodaContext() : base("name=FlodaConnection") { }

        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public System.Data.Entity.DbSet<Floda.Models.NhapHang> NhapHangs { get; set; }
    }
}