using InventoryManagement.ViewController;
using Ninject;
using System.Windows;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for NewInventoryWindow.xaml
    /// </summary>
    public partial class NewInventoryWindow : Window
    {
        private NewInventoryViewControler _newInventoryViewControler = NinjectContainer.Container.Get<NewInventoryViewControler>();

        public NewInventoryWindow()
        {
            InitializeComponent();
            this.DataContext = _newInventoryViewControler;
        }

        private void NewEditButton_Click(object sender, RoutedEventArgs e)
        {
            if(_newInventoryViewControler.SelectedZoneId == 0)
            {
                MessageBox.Show("Zone must be selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _newInventoryViewControler.CreateNewInventory(InventoryDescription.Text);

            this.Close();
        }
    }
}
