using System;
using System.Collections.Generic;
using System.Text;
using Aeneas.Models;

namespace Aeneas.DataController.LiteDB
{
    public class ProductDataController : IProductDataController
    {
        public IProductData Create()
        {
            return new ProductData();
        }

        public void Delete(IProductData product)
        {
            Database.ProductDataCollection.Delete(((ProductData)product).System_ObjectId);
        }

        public IEnumerable<IProductData> FindAll()
        {
            return Database.ProductDataCollection.FindAll();
        }

        public IEnumerable<IProductData> FindByMainCategory(string mainCategory)
        {
            return Database.ProductDataCollection.Find(x => x.MainCategory == mainCategory);
        }
    }
}
