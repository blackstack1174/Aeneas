using Aeneas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aeneas.DataController
{
    public interface IProductDataController
    {
        IProductData Create();
        void Delete(IProductData product);
        IEnumerable<IProductData> FindByMainCategory(string mainCategory);
        IEnumerable<IProductData> FindAll();
    }
}
