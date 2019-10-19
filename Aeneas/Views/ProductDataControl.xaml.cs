using Aeneas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aeneas.Views
{
    /// <summary>
    /// ProductDataControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductDataControl : UserControl
    {


        public void SetProductData(IProductData productData)
        {
            this.DataContext = productData;
        }
        public IProductData GetProductData()
        {
            return DataContext as IProductData;
        }
        public ProductDataControl()
        {
            InitializeComponent();
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            var productData = this.DataContext as IProductData;
            if (productData != null)
            {
                var productOption = new ProductOption();
                productOption.ID = Convert.ToInt32(this.optionsID.Text);
                productOption.Name = this.optionsName.Text;
                productOption.Price = this.optionsPrice.Text;
                productOption.Quantity = this.optionsQuantity.Text;
                productData.Options.Add(productOption);
            }

        }

        private void btnMainImages_Click(object sender, RoutedEventArgs e)
        {
            var productData = this.DataContext as IProductData;
            if (productData != null)
            {
                if (string.IsNullOrWhiteSpace(mainImage.Text) == false)
                {
                    productData.MainImage.Add(mainImage.Text);
                }
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            switch (menuItem.Header)
            {
                case "Delete":
                    var productData = DataContext as IProductData;
                    if (productData != null)
                    {
                        productData.Options.RemoveAt(Options.SelectedIndex);
                    }
                    break;
            }

        }
    }
}
