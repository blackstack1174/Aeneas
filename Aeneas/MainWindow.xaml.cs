using Aeneas.DataController;
using Aeneas.DataController.LiteDB;
using Aeneas.DataController.WebDB;
using Aeneas.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Aeneas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<IProductData> _productDataCollection = new ObservableCollection<IProductData>();
        private readonly object _lock = new object();
        Storyboard _sbSetEntity;
        public MainWindow()
        {
            InitializeComponent();

            Database.Initialize("temp.db");
            lsvProductList.ItemsSource = _productDataCollection;
            _controller = new DataController.LiteDB.ProductDataController();

            LoadProductDataList();
            _sbSetEntity = (Storyboard)this.FindResource("sbdOpenEntity");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindingOperations.EnableCollectionSynchronization(_productDataCollection, _lock);
        }

        public void LoadProductDataList()
        {
            new Task(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    _productDataCollection.Clear();
                    foreach (var item in _controller.FindAll())
                    {
                        _productDataCollection.Add(item);
                    }
                });
            }).Start();
        }


        IProductDataController _controller;

        private void lsvProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object selected = lsvProductList.SelectedItem;
            if (selected != null)
            {
                pdcMain.SetProductData(selected as IProductData);
                _sbSetEntity.Begin();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            pdcMain.SetProductData(_controller.Create());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _controller.Delete(pdcMain.GetProductData());
            LoadProductDataList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pdcMain.GetProductData().AddOrUpdate();
                LoadProductDataList();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("생성을 먼저해주세요.");
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as RadioButton;
            switch (checkBox.Content)
            {
                case "LiteDB":
                    Database.Initialize("temp.db");
                    _controller = new DataController.LiteDB.ProductDataController();
                    break;
                case "WebDB":
                    _controller = new DataController.WebDB.ProductDataController();
                    break;
            }
            lsvProductList.ItemsSource = _productDataCollection;
            LoadProductDataList();
        }


    }
}
