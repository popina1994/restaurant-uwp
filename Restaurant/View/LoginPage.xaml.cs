using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Restaurant.Logic;
using Restaurant.Model;
using Restaurant.Model.Tables;
using Restaurant.Services;
using Restaurant.Logic.Params;
using Restaurant.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var userPair = DatabaseModel.UserTable.FirstOrDefault(x => x.Value.UserName == TextBoxUserName.Text);
            if (DatabaseModel.UserTableDefault.Equals(userPair))
            {
                TextBlockError.Text = "Нема корисника са датим именом";
                TextBlockError.Visibility = Visibility.Visible;
                return;
            }
            User user = userPair.Value;
            if (user.Password != PasswordBoxPassword.Password)
            {
                TextBlockError.Text = "Нема корисника са датом шифром";
                TextBlockError.Visibility = Visibility.Visible;
                return;
            }

            ShellModel shellModel = Navigation.Shell.Model;

            shellModel.IsRegistered = true;
            shellModel.FullName = "     " + userPair.Value.FirstName + " " + userPair.Value.LastName;
            shellModel.UserName = userPair.Value.UserName;
            shellModel.Type = userPair.Value.Type;
            shellModel.User = user;
            shellModel.IsOrderer = user.Type == User.TYPE_ORDERER;
            shellModel.IsDeliverer = user.Type == User.TYPE_DELIVERER;
            Navigation.Navigate(typeof(HomePage));

        }
    }
}
