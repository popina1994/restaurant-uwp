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
using Restaurant.Logic.Params;
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
    public sealed partial class OrderInfoPage : Page
    {
        private OrderViewModel viewModel;
        public OrderInfoPage()
        {
            this.InitializeComponent();
            ViewModel = new OrderViewModel();
            ShellModel shellModel = Navigation.Shell.Model;

            ViewModel.IsDeliverer = shellModel.IsDeliverer;
            ViewModel.IsOrderer = shellModel.IsOrderer;
        }

        public OrderViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            OrderInfoParams orderInfoParams = (OrderInfoParams)e.Parameter;
            ViewModel.Order= orderInfoParams.Order;
        }


        private void ButtonDeliver_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Order.Status = Order.Delivered;
            ViewModel.Order.DateTimeDelivered = DateTime.Now;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Order.Status = Order.Canceled;
            ViewModel.Order.DateTimeDelivered = DateTime.Now;
        }

        private void CheckBoxPickedUp_OnChecked(object sender, RoutedEventArgs e)
        {
            bool checkedVal = (bool)((sender as CheckBox).IsChecked);
            OrderMealOption elem = (OrderMealOption)(sender as CheckBox).DataContext;
            if (elem is null) return;
            elem.PickedUp = checkedVal;

        }

        private void ListViewMealsOptions_OnItemClick(object sender, ItemClickEventArgs e)
        {
            OrderMealOption selectedMealOption = e.ClickedItem as OrderMealOption;
            if (ViewModel.IsDeliverer)
            {
                selectedMealOption.PickedUp = !selectedMealOption.PickedUp;
            }
            else
            {
                MealInfoParams mealInfoParams = new MealInfoParams(selectedMealOption.Meal);
                Navigation.Navigate(typeof(MealInfoPage), mealInfoParams);
            }


        }
    }
}
