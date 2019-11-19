using RestApi.Client.Dto.Response.Product;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace InventoryManagement.ViewController
{
    public class MainWindowViewController
    {
        public bool CanModifyUserData => true;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProductDto> Products { get; set; } = new ObservableCollection<ProductDto>();

        public MainWindowViewController()
        {
            Products.CollectionChanged += ProductsCollectionChanged;
        }


        private void ProductsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Products"));
            }
        }
    }
}
