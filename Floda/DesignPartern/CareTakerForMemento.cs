using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Floda.DesignPartern
{
    public class CareTakerForMemento
    {
        public Memento StoredProduct;
        public void SaveMementoToSession(Memento storedProduct)
        {
            HttpContext.Current.Session["Memento"] = storedProduct as Memento;
        }
    }
}