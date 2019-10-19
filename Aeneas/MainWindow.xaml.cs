using Aeneas.DataController;
using Aeneas.DataController.LiteDB;
using Aeneas.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Aeneas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<IProductData> _productDataCollection = new ObservableCollection<IProductData>();
        private readonly object _lock = new object();

        public MainWindow()
        {
            InitializeComponent();
            Database.Initialize("temp.db");
            BindingOperations.EnableCollectionSynchronization(_productDataCollection, _lock);
            _controller = new ProductDataController();
            lsvProductList.ItemsSource = _productDataCollection;

            LoadProductDataList();
        }


        public void LoadProductDataList()
        {
            new Task(() =>
            {
                _productDataCollection.Clear();
                foreach (var item in _controller.FindAll())
                {
                    _productDataCollection.Add(item);
                }
            }).Start();
        }


        IProductDataController _controller;

        private void lsvProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object selected = lsvProductList.SelectedItem;
            if (selected != null)
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
            pdcMain.GetProductData().AddOrUpdate();
            LoadProductDataList();
        }
    }
}
