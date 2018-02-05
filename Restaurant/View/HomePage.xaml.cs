using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
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
using Restaurant.ViewModel;
using Restaurant.Services;
using Restaurant.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private RestaurantViewModel viewModel;
        public HomePage()
        {
            this.InitializeComponent();
            var accesStatus = Geolocator.RequestAccessAsync();

            ObservableCollection<RestaurantSpec> ocRestaurantSpecs = new ObservableCollection<RestaurantSpec>();

            var matches = DatabaseModel.RestaurantTable.Where(pair => true).Select(pair=>pair.Value);

            foreach (var it in matches)
            {
                ocRestaurantSpecs.Add(it);
            }

            ObservableCollection<Meal> ocMeals = new ObservableCollection<Meal>();

            var matches2 = DatabaseModel.MealsTable.Where(pair => true).Select(pair => pair.Value);

            foreach (var it in matches2)
            {
                ocMeals.Add(it);
            }

            ObservableCollection<Order> ocOrders = new ObservableCollection<Order>();

            var matches3 = DatabaseModel.OrdersTable.Where(pair => true).Select(pair => pair.Value);

            foreach (var it in matches3)
            {
                ocOrders.Add(it);
            }


            this.viewModel = new RestaurantViewModel(ocRestaurantSpecs, ocMeals, ocOrders);
        }

        public RestaurantViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        private void ListViewRestaurant_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                
                RestaurantSpec selectedElement = e.AddedItems[0] as RestaurantSpec;
                RestaurantInfoParams restaurantInfoParams = new RestaurantInfoParams(selectedElement);
                Navigation.Navigate(typeof(RestaurantInfoPage),restaurantInfoParams) ;
            }
        }

        private void FilterRestaurant()
        {
            string name = SearchBox.Text;
            double ratingMin = SliderMinRating.Value;
            double ratingMax = SliderMaxRating.Value;
            bool checkMon = (bool)CheckBoxMon.IsChecked;
            TimeSpan time = TimePickerMonStart.Time;
            bool checkTue = (bool) CheckBoxTue.IsChecked;

            bool countCash = CheckboxCash.IsChecked != null;
            bool countVisa = CheckboxVisa.IsChecked != null;
            bool countPayPal = CheckboxPayPal.IsChecked != null;
            bool countMasterCard = CheckboxMaster.IsChecked != null;

            

            bool checkCash = countCash ? (bool)CheckboxCash.IsChecked : false;
            bool checkVisa = countVisa ? (bool)CheckboxVisa.IsChecked : false;
            bool checkPayPal = countPayPal ? (bool)CheckboxPayPal.IsChecked : false;
            bool checkMasterCard = countMasterCard ? (bool)CheckboxMaster.IsChecked : false;


            var matches = DatabaseModel.RestaurantTable.Where(pair => pair.Value.Name.Contains(name)
            && pair.Value.Address.Contains(TextBoxAddress.Text) && pair.Value.Kitchen.Contains(TextBoxKitchen.Text)
            && (pair.Value.Rating <= ratingMax) && (pair.Value.Rating >= ratingMin)                  
            && (!countCash || (checkCash == pair.Value.CanCash)) && (!countMasterCard || (checkMasterCard == pair.Value.CanMasterCard))
            && (!countPayPal || (checkPayPal == pair.Value.CanPayPal)) && (!countVisa || (checkVisa == pair.Value.CanVisa)))
                .Select(pair => pair.Value);

            this.ViewModel.Restaurants.Clear();

            foreach (var it in matches)
            {
                this.ViewModel.Restaurants.Add(it);
            }
    
        }

        private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (ViewModel.SelectedPivot == "PivotRestaurant")
            {
                FilterRestaurant();
            }
        }

        private void Pivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                PivotItem pivot = (PivotItem)e.AddedItems[0];
                ViewModel.SelectedPivot = pivot.Name;
            }
        }

        private void AutoSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {   
                if (ViewModel.SelectedPivot == "PivotRestaurant")
                {
                    FilterRestaurant();
                }
            }

        private void ListViewMeals_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {

                Meal selectedElement = e.AddedItems[0] as Meal;
                MealInfoParams mealInfoParams = new MealInfoParams(selectedElement);
                Navigation.Navigate(typeof(MealInfoPage), mealInfoParams);
            }
        }

        private void ButtonSearchRestaurantShow_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.IsSearchRestaurantShown = !ViewModel.IsSearchRestaurantShown;
            ButtonSearchRestaurantShow.Content = ViewModel.IsSearchRestaurantShown ? "\uE70E" : "\uE70D";
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
            Meal meal = (Meal) button.DataContext;
            meal.Amount--;
        }

        private void ButtonRestaurantsMeals_OnClick(object sender, RoutedEventArgs e)
        {
            Button buttonOrder = (Button) e.OriginalSource;
            RestaurantSpec selectedElement = (RestaurantSpec)buttonOrder.DataContext;
            PivotGlobal.SelectedItem = PivotItemMeal;
            TextBoxRestaurantMeal.Text = selectedElement.Name;
        }

        private void ListViewOrders_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Order selectedElement = e.AddedItems[0] as Order;
                OrderInfoParams orderInfoParams = new OrderInfoParams(selectedElement);
                Navigation.Navigate(typeof(OrderInfoPage), orderInfoParams);
            }
        }

        private void ListViewOrders_OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var clickedElement = ((FrameworkElement)e.OriginalSource).DataContext;
            if (clickedElement is Order)
            {
                Order order = (Order) clickedElement;
                ViewModel.SelectedOrder = order;

                ListView listView = (ListView)sender;
                MenuFlyoutOrder.ShowAt(listView, e.GetPosition(listView));

            }
            
        }

        private void MenuFlyoutItemG_OnClick(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = (MenuFlyoutItem) sender;
            switch (item.Name)
            {
                case "MenuFlyoutItemG1":
                    ViewModel.SelectedOrder.Group = 0;
                    break;
                case "MenuFlyoutItemG2":
                    ViewModel.SelectedOrder.Group = 1;
                    break;
                case "MenuFlyoutItemG3":
                    ViewModel.SelectedOrder.Group = 2;
                    break;
                case "MenuFlyoutItemG4":
                    ViewModel.SelectedOrder.Group = 3;
                    break;
                case "MenuFlyoutItemG5":
                    ViewModel.SelectedOrder.Group = 4;
                    break;
            }
        }
    }
}
