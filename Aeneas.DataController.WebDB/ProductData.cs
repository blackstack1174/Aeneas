using Aeneas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Aeneas.DataController.WebDB
{

    public class ProductData : IProductData
    {


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
            string serialize = JsonConvert.SerializeObject(this);
            Debug.WriteLine(serialize);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(serialize.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = httpClient.PostAsync(ProductDataController.AddUrl, content).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(responseString);
        }
    }
}
