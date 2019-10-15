using Aeneas.DataController;
using Aeneas.DataController.LiteDB;
using Aeneas.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Aeneas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.Initialize("temp.db");
            _controller = new ProductDataController();
            lsvProductList.ItemsSource = _productDataCollection;
            LoadProductDataList();
        }

        /// <summary>
        /// 비동기로 바꾸기
        /// </summary>
        public void LoadProductDataList()
        {
            _productDataCollection.Clear();
            foreach(var item in _controller.FindAll())
            {
                _productDataCollection.Add(item);
            }
        }


        IProductDataController _controller;

        /// <summary>
        /// 크로스스레드 처리
        /// </summary>
        ObservableCollection<IProductData> _productDataCollection = new ObservableCollection<IProductData>();

        private void lsvProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object selected = lsvProductList.SelectedItem;
            if(selected != null)
            {
                pdcMain.SetProductData(selected as IProductData);
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
            //pdcMain.GetProductData().AddOrUpdate();
            IProductData data = _controller.Create();
            data.ProductID = "11";
            data.AddOrUpdate();
            LoadProductDataList();
        }
    }
}
