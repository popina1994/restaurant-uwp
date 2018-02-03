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
using Restaurant.Model;
using Restaurant.Model.Tables;
using Restaurant.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
            var firstName = TextBoxFirstName.Text;
            var lastName = TextBoxLastName.Text;
            var password = PasswordBoxPassword.Password;
            var repatedPassword = PasswordBoxRepeatedPassword.Password;
            var userName = TextBoxUserName.Text;
            var phone = TextBoxPhone.Text;
            var address = TextBoxAddress.Text;
            var email = TextBoxEmail.Text;

            if (password != repatedPassword)
            {
                TextBlockError.Text = "Шифре нису исте";
                TextBlockError.Visibility = Visibility.Visible;
                return;
            }

            var userPair = DatabaseModel.UserTable.FirstOrDefault(x => x.Value.UserName == TextBoxUserName.Text);
            if (!DatabaseModel.UserTableDefault.Equals(userPair))
            {
                TextBlockError.Text = "Корисничко име је заузето";
                TextBlockError.Visibility = Visibility.Visible;
                return;
            }

            User user = new User(userName, password, User.TYPE_ORDERER, firstName, lastName, phone, address, email);
            DatabaseModel.UserTable.Add(user.Id, user);
            Navigation.Navigate(typeof(LoginPage));
        }
    }
}
