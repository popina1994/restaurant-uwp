using System;
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
using Restaurant.Services;
using Restaurant.ViewModel;
using Restaurant.Model;
using Restaurant.Model.Tables;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountEditPasswordPage : Page
    {
        private AccountInfoViewModel viewModel;

        public AccountEditPasswordPage()
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


        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxOldPassword.Password != ViewModel.User.Password)
            {
                TextBlockError.Visibility = Visibility.Visible;
                TextBlockError.Text = "Стара шифра нетачна";
                return;
            }

            if (PasswordBoxRepeatedPassword.Password != PasswordBoxPassword.Password)
            {
                TextBlockError.Visibility = Visibility.Visible;
                TextBlockError.Text = "Шифре се не поклапају";
                return;
            }

            string username = Navigation.Shell.Model.UserName;
            User user = DatabaseModel.UserTable.FirstOrDefault(x => x.Value.UserName == username).Value;

            user.Password = PasswordBoxPassword.Password;

            Navigation.Navigate(typeof(AccountInfoPage));
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(typeof(AccountInfoPage));
        }
    }
}
