﻿using InventoryManagement.ViewController;
using Microsoft.Win32;
using Ninject;
using RestApi.Client.Dto.Owner;
using RestApi.Client.Dto.Product;
using RestApi.Client.Dto.Response.Zone;
using System;
using System.IO;
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
                UserTab.Visibility = UserContext.CanAddUser() ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void ProductSearch_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindowViewController.SelectedSearchId == 0)
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
            if (_mainWindowViewController.SelectedProduct == null)
            {
                MessageBox.Show("Cannot remove item. Please select one first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _mainWindowViewController.RemoveSelectedProduct();
                ClearProductEditSection();
            };
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerCombo.SelectedItem = null;
            StatusDescriptionCombo.SelectedItem = null;
            ProductTypeCombo.SelectedItem = null;
            ZoneDescriptionCombo.SelectedItem = null;
            ProductDescription.Clear();
            _mainWindowViewController.NewProduct();
        }

        private void NewEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (OwnerCombo.SelectedItem == null || StatusDescriptionCombo.SelectedItem == null || ProductTypeCombo.SelectedItem == null || ZoneDescriptionCombo.SelectedItem == null || string.IsNullOrWhiteSpace(ProductDescription.Text))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _mainWindowViewController.AddNewProduct((ProductTypeDto)ProductTypeCombo.SelectedItem, (OwnerDto)OwnerCombo.SelectedItem, (ProductStatusDto)StatusDescriptionCombo.SelectedItem, (ZoneDto)ZoneDescriptionCombo.SelectedItem, ProductDescription.Text);
            ClearProductEditSection();
        }

        private void ClearProductEditSection()
        {
            OwnerCombo.SelectedItem = null;
            StatusDescriptionCombo.SelectedItem = null;
            ProductTypeCombo.SelectedItem = null;
            ZoneDescriptionCombo.SelectedItem = null;
            ProductDescription.Clear();
            _mainWindowViewController.NewProduct();
        }

        private void GetQRButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindowViewController.SelectedProduct == null)
            {
                MessageBox.Show("Select item first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var product = _mainWindowViewController.Products.First(x => x.Id == _mainWindowViewController.SelectedProduct.ProductId);

            QRViewWindow window = new QRViewWindow(product);

            window.ShowDialog();
        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            UserNameTextBox.Clear();
            UserLastNameTextBox.Clear();
            UserLoginTextBox.Clear();
            UserPassword.Clear();
            UserZoneCombo.SelectedItem = null;
            IsAdminCheckBox.IsChecked = false;
            ActiveCheckBox.IsChecked = false;
            _mainWindowViewController.SelectedUser = null;
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindowViewController.SelectedUser == null)
            {
                MessageBox.Show("Cannot remove item. Please select one first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to deactivate this ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _mainWindowViewController.DeactivateCurrentUser();
                ClearProductEditSection();
            };
        }

        private void SaveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindowViewController.SelectedUser != null)
            {
                if (!string.IsNullOrWhiteSpace(UserPassword.Password) && MessageBox.Show("Are you sure that you want to change password ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
            }
            else
            {
                if (UserPassword.Password == null)
                {
                    MessageBox.Show("Password need to be set while creating new user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            try
            {
                _mainWindowViewController.SaveUser(UserNameTextBox.Text, UserLastNameTextBox.Text, UserLoginTextBox.Text, UserPassword.Password, (UserZoneCombo.SelectedItem as ZoneDto).Id, ActiveCheckBox.IsChecked.Value, IsAdminCheckBox.IsChecked.Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable  to finish operation because of exception. Make sure that you entered correct data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void SearchInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindowViewController.SelectedInventorySearchId == 0)
            {
                MessageBox.Show("Search must be selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                _mainWindowViewController.FillInventoryList();
            }
        }

        private void NewInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            NewInventoryWindow newInventoryWindow = new NewInventoryWindow();

            newInventoryWindow.ShowDialog();

            if (_mainWindowViewController.SelectedInventorySearchId == 0)
            {
                return;
            }

            _mainWindowViewController.FillInventoryList();
        }

        private void ActivateInvenoryButton_Click(object sender, RoutedEventArgs e)
        {
            if(_mainWindowViewController.SelectedInventory == null)
            {
                MessageBox.Show("Please select item that you want to change status", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (_mainWindowViewController.SelectedInventorySearchId == 0)
            {
                return;
            }

            _mainWindowViewController.ChangeInventoryStatus(2);

            _mainWindowViewController.FillInventoryList();
        }

        private void FinishInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindowViewController.SelectedInventory == null)
            {
                MessageBox.Show("Please select item that you want to change status", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show("Are you sure that you want to complete this inventory? \n Unscanned items will be displayed on final report", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            if (_mainWindowViewController.SelectedInventorySearchId == 0)
            {
                return;
            }

            _mainWindowViewController.ChangeInventoryStatus(3);

            _mainWindowViewController.FillInventoryList();
        }

        private void AbandonInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindowViewController.SelectedInventory == null)
            {
                MessageBox.Show("Please select item that you want to change status", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show("Are you sure that you want to abandon this inventory? \n Final report will not be created for this inventory", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            if (_mainWindowViewController.SelectedInventorySearchId == 0)
            {
                return;
            }

            _mainWindowViewController.ChangeInventoryStatus(4);

            _mainWindowViewController.FillInventoryList();
        }

        private void InventoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_mainWindowViewController.SelectedInventory == null)
            {
                return;
            }
            _mainWindowViewController.FillInventoryProductList();

            ActivateInvenoryButton.IsEnabled = _mainWindowViewController.ShouldAllowToActivateInventory();

            FinishInventoryButton.IsEnabled = _mainWindowViewController.ShouldAllowToFinishInvenory();

            AbandonInventoryButton.IsEnabled = _mainWindowViewController.ShouldAllowToAbandonInventory();

            GetRaportInventoryButton.IsEnabled = _mainWindowViewController.ShouldAllowToViewRaport();
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_mainWindowViewController.SelectedUser == null)
            {
                return;
            }
            UserZoneCombo.SelectedItem = _mainWindowViewController.AvailableZones.First(x => x.Id == _mainWindowViewController.SelectedUser.ZoneId);
            UserNameTextBox.Text = _mainWindowViewController.SelectedUser.Name;
            UserLastNameTextBox.Text = _mainWindowViewController.SelectedUser.LastName;
            UserLoginTextBox.Text = _mainWindowViewController.SelectedUser.Login;
            IsAdminCheckBox.IsChecked = _mainWindowViewController.SelectedUser.IsAdmin;
            ActiveCheckBox.IsChecked = _mainWindowViewController.SelectedUser.Active;
        }

        private void ProductDataGird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_mainWindowViewController.SelectedProduct == null)
            {
                return;
            }

            OwnerCombo.SelectedItem = _mainWindowViewController.AvailableOwners.First(x => x.Name == _mainWindowViewController.SelectedProduct.OwnerDescription);
            StatusDescriptionCombo.SelectedItem = _mainWindowViewController.AvailableProductStatuses.First(x => x.Description == _mainWindowViewController.SelectedProduct.StatusDescription);
            ProductTypeCombo.SelectedItem = _mainWindowViewController.AvailableProductTypes.First(x => x.Description == _mainWindowViewController.SelectedProduct.ProductType);
            ZoneDescriptionCombo.SelectedItem = _mainWindowViewController.AvailableZones.First(x => x.Description == _mainWindowViewController.SelectedProduct.ZoneDescription);
            ProductDescription.Text = _mainWindowViewController.SelectedProduct.ProductDescription;
        }

        private void GetRaportInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            var report = _mainWindowViewController.GetReportString();
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = $"Inventory {_mainWindowViewController.SelectedInventory.Id} reprot.txt";

            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == true)

            {

                StreamWriter writer = new StreamWriter(save.OpenFile());

                writer.WriteLine(report);

                writer.Dispose();

                writer.Close();

            }
        }
    }
}