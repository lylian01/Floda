using Floda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floda.DesignPartern.ProductsProxyParttern
{
    public abstract class Product
    {
        public abstract void AddProduct();
        public abstract void EditProduct();
        public abstract void DeleteProduct();

    }
}
