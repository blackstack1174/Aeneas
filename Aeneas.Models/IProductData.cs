using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Aeneas.Models
{
    public interface IProductData : INotifyPropertyChanged
    {
        string ProductID { get; set; }
        string MainCategory { get; set; }
        string SubCategory { get; set; }
        string SmallCategory { get; set; }
        string DetailCategory { get; set; }

        string Name { get; set; }

        ObservableCollection<string> MainImage { get; set; }

        string Price { get; set; }
        string DiscountPrice { get; set; }

        string DeliveryBasicFee { get; set; }
        string DeliveryReturnFee { get; set; }
        string DeliveryReturnAddress { get; set; }
        string DeliveryChangeFee { get; set; }

        string DeliveryChangeAddres { get; set; }

        ObservableCollection<ProductOption> Options { get; set; }

        string DetailHtml { get; set; }


        void AddOrUpdate();
    }
}
