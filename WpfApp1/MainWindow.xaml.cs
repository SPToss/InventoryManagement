using Domain;
using InventoryManagement.Extension;
using InventoryManagement.ViewController;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewController _mainWindowViewController = new MainWindowViewController();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _mainWindowViewController;

            if (_mainWindowViewController.CanModifyUserData)
            {
                UserTab.Visibility = Visibility.Visible;
            }
        }
    }
}
