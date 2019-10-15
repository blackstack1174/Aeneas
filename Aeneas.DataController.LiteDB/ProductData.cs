using Aeneas.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aeneas.DataController.LiteDB
{
    public class ProductData : IProductData
    {
        internal ObjectId System_ObjectId { get; set; } = ObjectId.NewObjectId();
        public string ProductID { get; set; }
        public string MainCategory { get; set;}
        public string SubCategory { get; set;}
        public string SmallCategory { get; set;}
        public string DetailCategory { get; set;}
        public string Name { get; set;}
        public List<string> MainImage { get; set;}
        public string Price { get; set;}
        public string DiscountPrice { get; set;}
        public string DeliveryBasicFee { get; set;}
        public string DeliveryReturnFee { get; set;}
        public string DeliveryReturnAddress { get; set;}
        public string DeliveryChangeFee { get; set;}
        public string DeliveryChangeAddres { get; set;}
        public List<ProductOption> Options { get; set;}
        public string DetailHtml { get; set;}

        public void AddOrUpdate()
        {
            ProductData data = this;
            if(Database.ProductDataCollection.Exists(x => x.System_ObjectId == data.System_ObjectId))
            {
                Database.ProductDataCollection.Update(data);
            }
            else 
            {
                Database.ProductDataCollection.Insert(data);
            }
        }
    }
}
