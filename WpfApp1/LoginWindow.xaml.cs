﻿using Ninject;
using RestApi.Client.Interface;
using System;
using System.Windows;
using System.Windows.Input;
using RestApi.Client.Dto.Response.User;
using RestApi.Client.Dto.Request.User;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IRestApiClient _restApiClient;

        public LoginWindow()
        {
            InitializeComponent();
            _restApiClient = NinjectContainer.Container.Get<IRestApiClient>();

            #region events
            KeyDown += new KeyEventHandler(KeyDownEventHandler);
            #endregion events
        }

        #region eventHandlersImplementation

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Authorize();
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Authorize();
            }
        }

        #endregion eventHandlersImplementation

        private void Authorize()
        {
            UserResponseDto user = null;
            try
            {
                user = _restApiClient.Authorize(new UserAuthorizeRequestDto
                {
                    Login = Login.Text,
                    Password = Password.Password
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error durring login process", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (user == null)
            {
                MessageBox.Show("Invalid User name or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UserContext.SetUser(user);
            this.Hide();
            MainWindow mainWindow = NinjectContainer.Container.Get<MainWindow>();
            mainWindow.Owner = this.Owner;
            mainWindow.ShowDialog();
        }
    }
}