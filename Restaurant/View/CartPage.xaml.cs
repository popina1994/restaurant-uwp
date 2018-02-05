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
using Restaurant.Model.Tables;
using Restaurant.ViewModel;
using System.Collections.ObjectModel;
using Restaurant.Model;
using Restaurant.Services;
using Restaurant.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CartPage : Page
    {
        private CartViewModel viewModel;

        public CartPage()
        {
            this.InitializeComponent();
            ObservableCollection<Meal> ocMeals = new ObservableCollection<Meal>();

            var matches2 = DatabaseModel.MealsTable.Where(pair => pair.Value.Amount > 0).Select(pair => pair.Value);

            foreach (var it in matches2)
            {
                ocMeals.Add(it);
            }

            this.viewModel = new CartViewModel(ocMeals);
        }

        public CartViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        private void ListViewMeals_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ButtonIncAmount_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.OriginalSource;
            Meal meal = (Meal)button.DataContext;
            meal.Amount++;
        }

        private void ButtonDecAmount_OnClick(object sender, RoutedEventArgs e)
        {

            Button button = (Button)e.OriginalSource;
            Meal meal = (Meal)button.DataContext;
            meal.Amount--;
            if (meal.Amount == 0)
            {
                ViewModel.Meals.Remove(meal);
            }
        }

        private void ButtonChoosePayment_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(typeof(PaymentPage));
        }
    }
}
