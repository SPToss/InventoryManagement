using DataTransfer.ProductType;
using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ViewController
{
    public class MainWindowViewController
    {
        public bool CanModifyUserData => true;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

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
