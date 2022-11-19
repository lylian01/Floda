using Floda.DesignPartern.ProductsProxyParttern;
using Floda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floda.DesignPartern
{
    public class ProductProxyParttern  : Product
    {
        Product product;
        SanPham sanpham;
        int id;
        public ProductProxyParttern()
        {
            product = null;
        }

        public ProductProxyParttern(SanPham sanpham)
        {
            this.sanpham = sanpham;
        }
        public ProductProxyParttern(int id)
        {
            this.id = id;
        }

        public override void AddProduct()
        {
            if(product == null)
            {
                product=new ConcreteProduct(sanpham);
            }
            product.AddProduct();
        }

        public override void DeleteProduct()
        {
            if (product == null)
            {
                product = new ConcreteProduct(id);
            } 
            product.DeleteProduct();
        }

        public override void EditProduct()
        {
            if (product == null)
            {
                product = new ConcreteProduct(sanpham);
            }
            product.EditProduct();
        }
    }
}
