using Aeneas.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Aeneas.DataController.LiteDB
{
    public class ProductData : IProductData
    {
        [BsonId]
        public ObjectId System_ObjectId { get; set; } = ObjectId.NewObjectId();


        private string _productID = "toy";
        public string ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
                Changed("ProductID");
            }
        }
        private string _mainCategory = "toy";
        public string MainCategory
        {
            get
            {
                return _mainCategory;
            }
            set
            {
                _mainCategory = value;
                Changed("MainCategory");
            }
        }
        private string _subCategory = "toy";
        public string SubCategory
        {
            get
            {
                return _subCategory;
            }
            set
            {
                _subCategory = value;
                Changed("SubCategory");
            }
        }
        private string _smallCategory = "toy";
        public string SmallCategory
        {
            get
            {
                return _smallCategory;
            }
            set
            {
                _smallCategory = value;
                Changed("SmallCategory");
            }
        }

        private string _detailCategory = "toy";
        public string DetailCategory
        {
            get
            {
                return _detailCategory;
            }
            set
            {
                _detailCategory = value;
                Changed("DetailCategory");
            }
        }
        private string _name = "toy";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Changed("Name");
            }
        }

        private string _price = "toy";
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                Changed("Price");
            }
        }
        private string _discountPrice = "toy";
        public string DiscountPrice
        {
            get
            {
                return _discountPrice;
            }
            set
            {
                _discountPrice = value;
                Changed("DiscountPrice");
            }
        }

        private string _deliveryBasicFee = "toy";
        public string DeliveryBasicFee
        {
            get
            {
                return _deliveryBasicFee;
            }
            set
            {
                _deliveryBasicFee = value;
                Changed("DeliveryBasicFee");
            }
        }

        private string _deliveryReturnFee = "toy";
        public string DeliveryReturnFee
        {
            get
            {
                return _deliveryReturnFee;
            }
            set
            {
                _deliveryReturnFee = value;
                Changed("DeliveryReturnFee");
            }
        }

        private string _deliveryReturnAddress = "toy";
        public string DeliveryReturnAddress
        {
            get
            {
                return _deliveryReturnAddress;
            }
            set
            {
                _deliveryReturnAddress = value;
                Changed("DeliveryReturnAddress");
            }
        }
        private string _deliveryChangeFee = "toy";
        public string DeliveryChangeFee
        {
            get
            {
                return _deliveryChangeFee;
            }
            set
            {
                _deliveryChangeFee = value;
                Changed("DeliveryChangeFee");
            }
        }

        private string _deliveryChangeAddres = "toy";
        public string DeliveryChangeAddres
        {
            get
            {
                return _deliveryChangeAddres;
            }
            set
            {
                _deliveryChangeAddres = value;
                Changed("DeliveryChangeAddres");
            }
        }
        private string _detailHtml = "toy";
        public string DetailHtml
        {
            get
            {
                return _detailHtml;
            }
            set
            {
                _detailHtml = value;
                Changed("DetailHtml");
            }
        }
        private ObservableCollection<string> _mainImage = new ObservableCollection<string>();
        public ObservableCollection<string> MainImage
        {
            get
            {
                return _mainImage;
            }
            set
            {
                _mainImage = value;
                Changed("MainImage");
            }

        }
        private ObservableCollection<ProductOption> _options = new ObservableCollection<ProductOption>();
        public ObservableCollection<ProductOption> Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
                Changed("Options");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AddOrUpdate()
        {
            ProductData data = this;
            if (Database.ProductDataCollection.Exists(x => x.System_ObjectId == data.System_ObjectId))
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
