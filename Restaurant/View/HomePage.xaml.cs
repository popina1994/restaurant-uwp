﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            this.viewModel = new RestaurantViewModel(ocRestaurantSpecs, ocMeals);
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
            throw new NotImplementedException();
        }

        private void ButtonSearchRestaurantShow_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.IsSearchRestaurantShown = !ViewModel.IsSearchRestaurantShown;
            ButtonSearchRestaurantShow.Content = ViewModel.IsSearchRestaurantShown ? "\uE70E" : "\uE70D";
        }
    }
}
