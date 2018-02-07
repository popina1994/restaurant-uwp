using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
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

            var matches = DatabaseModel.RestaurantTable.Where(pair => true).Select(pair => pair.Value);

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

            
            DateTime dateTime = new DateTime(2001, 1, 1);
            DateTimeOffset offset = DateTime.SpecifyKind(dateTime, DateTimeKind.Local);

            DatePickerFrom.Date = offset;
            
            this.viewModel = new RestaurantViewModel(ocRestaurantSpecs, ocMeals, ocOrders);
            ShellModel shellModel = Navigation.Shell.Model;
            ViewModel.IsDeliverer = shellModel.IsDeliverer;
            ViewModel.IsOrderer = shellModel.IsOrderer;
            ViewModel.IsUnregistered = !shellModel.IsRegistered;
            FilterOrders();
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
                Navigation.Navigate(typeof(RestaurantInfoPage), restaurantInfoParams);
            }
        }

        private void FilterRestaurant()
        {
            string name = SearchBox.Text;
            double ratingMin = SliderMinRating.Value;
            double ratingMax = SliderMaxRating.Value;
            bool checkMon = (bool)CheckBoxMon.IsChecked;
            bool checkTue = (bool)CheckBoxTue.IsChecked;
            bool checkWed = (bool)CheckBoxWed.IsChecked;
            bool checkThu = (bool)CheckBoxThu.IsChecked;
            bool checkFri = (bool)CheckBoxFri.IsChecked;
            bool checkSat = (bool)CheckBoxSat.IsChecked;
            bool checkSun = (bool)CheckBoxSun.IsChecked;

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
            && (!countPayPal || (checkPayPal == pair.Value.CanPayPal)) && (!countVisa || (checkVisa == pair.Value.CanVisa))
            && (!checkMon || ((pair.Value.MonWorkingHoursStart <= TimePickerMonStart.Time) && (pair.Value.MonWorkingHoursEnd >= TimePickerMonEnd.Time)))
            && (!checkTue || ((pair.Value.TueWorkingHoursStart <= TimePickerTueStart.Time) && (pair.Value.TueWorkingHoursEnd >= TimePickerTueEnd.Time)))
            && (!checkWed || ((pair.Value.WedWorkingHoursStart <= TimePickerWedStart.Time) && (pair.Value.WedWorkingHoursEnd >= TimePickerWedEnd.Time)))
            && (!checkThu || ((pair.Value.ThuWorkingHoursStart <= TimePickerThuStart.Time) && (pair.Value.ThuWorkingHoursEnd >= TimePickerThuEnd.Time)))
            && (!checkFri || ((pair.Value.FriWorkingHoursStart <= TimePickerFriStart.Time) && (pair.Value.FriWorkingHoursEnd >= TimePickerFriEnd.Time)))
            && (!checkSat || ((pair.Value.SatWorkingHoursStart <= TimePickerSatStart.Time) && (pair.Value.SatWorkingHoursEnd >= TimePickerSatEnd.Time)))
            && (!checkSun || ((pair.Value.SunWorkingHoursStart <= TimePickerSunStart.Time) && (pair.Value.SunWorkingHoursEnd >= TimePickerSunEnd.Time)))
            && (pair.Value.Description.Contains(TextBoxDescriptionRestaurant.Text)) && (pair.Value.DeliveryTime < TimePickerDeliveryTime.Time))
                .Select(pair => pair.Value);

            this.ViewModel.Restaurants.Clear();

            foreach (var it in matches)
            {
                this.ViewModel.Restaurants.Add(it);
            }

        }

        private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            switch (ViewModel.SelectedPivot)
            {
                case "PivotItemRestaurant":
                    FilterRestaurant();
                    break;
                case "PivotItemMeal":
                    FilterMeal();
                    break;
                case "PivotItemOrder":
                    FilterOrders();
                    break;
            }
        }

        private void Pivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                PivotItem pivot = (PivotItem)e.AddedItems[0];
                ViewModel.SelectedPivot = pivot.Name;
                switch (pivot.Name)
                {
                    case "PivotItemRestaurant":
                        SearchBox.PlaceholderText = "Ресторан";
                        break;
                    case "PivotItemMeal":
                        SearchBox.PlaceholderText = "Јела";
                        break;
                    case "PivotItemOrder":
                        SearchBox.PlaceholderText = "Поруџбина";
                        break;
                }
            }
        }

        private void AutoSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            switch (ViewModel.SelectedPivot)
            {
                case "PivotItemRestaurant":
                    FilterRestaurant();
                    break;
                case "PivotItemMeal":
                    FilterMeal();
                    break;
                case "PivotItemOrder":
                    FilterOrders();
                    break;
            }
        }

        private void FilterOrders()
        {
            /*
            IEnumerable<Order> matches;
            if (isInit)
            {
                matches = DatabaseModel.OrdersTable.Where(
                    x => (true)
                ).Select(pair => pair.Value);
            }
            else
            {
            */
                var matches = DatabaseModel.OrdersTable.Where(
                    x => (x.Value.DateTimeOrdered >= DatePickerFrom.Date.DateTime)
                       && ((x.Value.Status == Order.NotDelivered) || (x.Value.DateTimeDelivered <= DatePickerTo.Date.DateTime))
                       && ((x.Value.Amount > Int32.Parse(TextBoxMinPrice.Text)
                        && (x.Value.Amount < Int32.Parse((TextBoxMaxPrice.Text)))))

                    ).Select(pair => pair.Value);
            //}
            this.ViewModel.Orders.Clear();
            if (ViewModel.IsDeliverer)
            {
                foreach (var it in matches)
                {
                    if (it.Status == Order.NotDelivered)
                    {
                        this.ViewModel.Orders.Add(it);
                    }
                }
            }
            else
            {
                foreach (var it in matches)
                {
                    if (it.User.Id == Navigation.Shell.Model.User.Id)
                    {
                        this.ViewModel.Orders.Add(it);
                    }
                }
            }

        }

        private void FilterMeal()
        {
            string name = SearchBox.Text;
            double ratingMin = SliderMinRatingMeal.Value;
            double ratingMax = SliderMaxRatingMeal.Value;

            bool checkedBrekfeast = (bool)CheckboxBreakfeast.IsChecked;
            bool checkedLunch = (bool)CheckboxLunch.IsChecked;
            bool checkedDinner = (bool)CheckboxDinner.IsChecked;

            var matches = DatabaseModel.MealsTable.Where(pair => pair.Value.Name.Contains(name)
            && (pair.Value.Rating <= ratingMax) && (pair.Value.Rating >= ratingMin)
            && (pair.Value.Restaurant.Name.Contains(TextBoxRestaurantMeal.Text))
            && (pair.Value.Price >= SliderMinPrice.Value) && (pair.Value.Price <= SliderMaxPrice.Value)
            && (pair.Value.Restaurant.Kitchen.Contains(TextBoxKitchenMeal.Text))
            && (pair.Value.Description.Contains(TextBoxDescriptionMeal.Text))
            && (pair.Value.Category.Contains("Доручак") || !checkedBrekfeast)
            && (pair.Value.Category.Contains("Ручак") || !checkedLunch)
            && (pair.Value.Category.Contains("Вечерас") || !checkedDinner)
                ).Select(pair => pair.Value);

            this.ViewModel.Meals.Clear();

            string withoutWhiteSpace = Regex.Replace(TextBoxIngridientsMeal.Text, @"\s+", "");
            string[] ingridients = withoutWhiteSpace.Split(',');
            foreach (var it in matches)
            {
                bool containsAll = true;
                foreach (var itIng in ingridients)
                {
                    if (!it.Ingridients.ToLower().Contains(itIng.ToLower()))
                    {
                        containsAll = false;
                        break;
                    }
                }

                if (containsAll)
                {
                    this.ViewModel.Meals.Add(it);
                }


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
            Meal meal = (Meal)button.DataContext;
            meal.Amount--;
        }

        private void ButtonRestaurantsMeals_OnClick(object sender, RoutedEventArgs e)
        {
            Button buttonOrder = (Button)e.OriginalSource;
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
                Order order = (Order)clickedElement;
                ViewModel.SelectedOrder = order;

                ListView listView = (ListView)sender;
                MenuFlyoutOrder.ShowAt(listView, e.GetPosition(listView));

            }

        }

        private void MenuFlyoutItemG_OnClick(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = (MenuFlyoutItem)sender;
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

        private void ListViewMealsOptions_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ViewModel.IsUnregistered) return;
            if (e.AddedItems.Count > 0)
            {
                OrderMealOption orderMealOption = e.AddedItems[0] as OrderMealOption;
                if (ViewModel.IsOrderer)
                {
                    MealInfoParams mealInfoParams = new MealInfoParams(orderMealOption.Meal);
                    Navigation.Navigate(typeof(MealInfoPage), mealInfoParams);
                }
                else
                {
                    RestaurantInfoParams restaurantInfoParams = new RestaurantInfoParams(orderMealOption.Meal.Restaurant);
                    Navigation.Navigate(typeof(RestaurantInfoPage), restaurantInfoParams);
                }
            }
        }

        private void ButtonSearchMealShow_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.IsSearchMealShown= !ViewModel.IsSearchMealShown;
            ButtonSearchMealShow.Content = ViewModel.IsSearchMealShown? "\uE70E" : "\uE70D";

        }

        private void ButtonSearchOrderShow_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.IsSearchOrderShown = !ViewModel.IsSearchOrderShown;
            ButtonSearchOrderShow.Content = ViewModel.IsSearchOrderShown ? "\uE70E" : "\uE70D";
        }
    }
}
