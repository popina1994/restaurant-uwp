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
using Restaurant.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaymentPage : Page
    {

        private PaymentViewModel viewModel;

        public PaymentPage()
        {
            this.InitializeComponent();

            int price = 0;

            foreach (var it in DatabaseModel.MealsTable.Values)
            {
                if (it.Amount > 0)
                {
                    price += it.Amount * it.Price;
                }
            }

            ViewModel = new PaymentViewModel(price);
        }

        public PaymentViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        private void ButtonPay_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Add checks.
            TextBlockResult.Text = "УСПЕШНО ПЛАЋАЊЕ";
            TextBlockResult.Visibility = Visibility.Visible;
            
            Dictionary<int, OrderMealOption> orderMealOptions = new Dictionary<int, OrderMealOption>();
            int fulAmount = 0;

            foreach (var it in DatabaseModel.MealsTable.Values)
            {
                if (it.Amount > 0)
                {
                    OrderMealOption orderMealOption = new OrderMealOption(it, it.Amount, false);
                    orderMealOptions.Add(orderMealOption.Id, orderMealOption);
                    fulAmount += it.Amount;
                    it.Amount = 0;
                }
            }
            string paidBy = Order.PaidMaster;

            if ((bool) RadioButtonOptionCash.IsChecked)
            {
                paidBy = Order.PaidCash;
            }
            else if ((bool)RadioButtonOptionMasterCard.IsChecked)
            {
                paidBy = Order.PaidMaster;
            }
            else if ((bool) RadioButtonOptionVisa.IsChecked)
            {
                paidBy = Order.PaidVisa;
            }
            else
            {
                paidBy = Order.PaidPayPal;
            }


            var dateTimeToday = DateTime.Now;

            var date = dateTimeToday.ToString("dd-MM-yyyy");
            

            User user = DatabaseModel.UserTable.FirstOrDefault(x => x.Value.UserName == Navigation.Shell.Model.UserName).Value;
            
            Order order = new Order(user, orderMealOptions, fulAmount, Order.NotDelivered, paidBy, date, "", 0);
            DatabaseModel.OrdersTable.Add(order.Id, order);
        }
    }
}
