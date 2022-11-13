using Floda.DAL;
using Floda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Floda.DesignPartern
{
    class FlowerCategorySingleton
    {

        private FlodaContext db = new FlodaContext();
        public static volatile FlowerCategorySingleton Instance;
        private static readonly object lockObject = new object();

        public FlowerCategorySingleton()
        {

        }

        public static FlowerCategorySingleton GetInstance()
        {
            if(Instance == null)
            {
                lock (lockObject) ;
                if (Instance == null) {
                    Instance = new FlowerCategorySingleton();
                }
            }
            return Instance;
        }

        public void AddCategotyFlower(LoaiSanPham loaiSanPham)
        {
            db.LoaiSanPhams.Add(loaiSanPham);
            db.SaveChanges();
        }

        public void RemoveCategotyFlower(int id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            db.LoaiSanPhams.Remove(loaiSanPham);
            db.SaveChanges();
        }

        public void EditCategotyFlower(LoaiSanPham loaiSanPham)
        {
            db.Entry(loaiSanPham).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
