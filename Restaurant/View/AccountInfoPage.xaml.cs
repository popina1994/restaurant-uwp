﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Restaurant.Model;
using Restaurant.Model.Tables;
using Restaurant.Services;
using Restaurant.View;
using Restaurant.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountInfoPage : Page
    {
        private AccountInfoViewModel viewModel;

        public AccountInfoPage()
        {
            
            this.InitializeComponent();

            string username = Navigation.Shell.Model.UserName;
            var userPair = DatabaseModel.UserTable.FirstOrDefault(x => x.Value.UserName == username);
            User user = null;
            if (!DatabaseModel.UserTableDefault.Equals(userPair))
            {
                user = userPair.Value;
            }
            AccountInfoViewModel viewModel = new AccountInfoViewModel(user);
            this.ViewModel = viewModel;

        }

        public AccountInfoViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(typeof(AccountEditPage));
        }

        private void EditPassword_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(typeof(AccountEditPasswordPage));
        }

        private void LogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Shell.Model.Unregister();
            Navigation.Navigate(typeof(HomePage));
        }
    }
}
