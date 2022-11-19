using Floda.DAL;
using Floda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floda.DesignPartern.ProductsProxyParttern
{
    public class ConcreteProduct : Product
    {
        SanPham sanpham;
        int id;

        private FlodaContext db = new FlodaContext();
        public ConcreteProduct(SanPham product)
        {
            this.sanpham = product;
        }

        public ConcreteProduct(int id)
        {
            this.id = id;
        }
        public override void AddProduct()
        {
            db.SanPhams.Add(sanpham);
            db.SaveChanges();
        }

        public override void DeleteProduct()
        {
            SanPham sanPhamDelete = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPhamDelete);
            db.SaveChanges();
        }

        public override void EditProduct()
        {
            db.Entry(sanpham).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
