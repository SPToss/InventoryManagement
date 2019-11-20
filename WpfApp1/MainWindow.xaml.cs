using InventoryManagement.ViewController;
using Ninject;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewController _mainWindowViewController = NinjectContainer.Container.Get<MainWindowViewController>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _mainWindowViewController;

            ProductDataGird.AutoGeneratingColumn += (s, e) =>
            {
                if (e.PropertyName == "ProductDescription")
                {
                    e.Column.Width = 250;
                    DataGridBoundColumn column = e.Column as DataGridBoundColumn;
                    if (column != null)
                    {
                        column.Binding = new Binding(e.PropertyName);

                        Style elementStyle = new Style(typeof(TextBlock));
                        elementStyle.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.WrapWithOverflow));
                        column.ElementStyle = elementStyle;
                    }
                }

                if (e.PropertyName == "ZoneDescription")
                {
                    e.Column.Width = 100;
                    DataGridBoundColumn column = e.Column as DataGridBoundColumn;
                    if (column != null)
                    {
                        column.Binding = new Binding(e.PropertyName);

                        Style elementStyle = new Style(typeof(TextBlock));
                        elementStyle.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.WrapWithOverflow));
                        column.ElementStyle = elementStyle;
                    }
                }
            };

            if (_mainWindowViewController.CanModifyUserData)
            {
                UserTab.Visibility = Visibility.Visible;
            }
        }

        private void ProductSearch_Click(object sender, RoutedEventArgs e)
        {
            if(_mainWindowViewController.SelectedSearchId == 0)
            {
                MessageBox.Show("Search must be selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                _mainWindowViewController.FillProductList();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(_mainWindowViewController.SelectedProduct == null)
            {
                MessageBox.Show("Cannot remove item. Please select one first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _mainWindowViewController.RemoveSelectedProduct();

        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerCombo.Items.Refresh();
            ProductDescription.Clear();
            ProductTypeCombo.Items.Refresh();
            StatusDescriptionCombo.Items.Refresh();
            ZoneDescriptionCombo.Items.Refresh();
            _mainWindowViewController.NewProduct();
        }
    }
}
