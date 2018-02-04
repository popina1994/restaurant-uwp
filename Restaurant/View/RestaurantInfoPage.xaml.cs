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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RestaurantInfoPage : Page
    {
        private RestaurantInfoViewModel viewModel;

        public RestaurantInfoPage()
        {
            this.InitializeComponent();
            viewModel = new RestaurantInfoViewModel(null);

        }

        public RestaurantInfoViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            RestaurantInfoParams restaurantInfoParams = (RestaurantInfoParams) e.Parameter;
            ViewModel.Restaurant = restaurantInfoParams.Restaurant;
            ViewModel.CurImageIdx = 0;
            ViewModel.ImagePath = ViewModel.Restaurant.ImagePathLinkedList.ElementAt(ViewModel.CurImageIdx);

            ObservableCollection<CommentRestaurant> ocComm = new ObservableCollection<CommentRestaurant>();
            foreach (var it in DatabaseModel.CommentRestaurantsTable)
            {
                if (it.Value.Restaurant.Id == ViewModel.Restaurant.Id)
                {
                    ocComm.Add(it.Value);
                }
            }

            ViewModel.CommentRestaurants = ocComm;

            var accesStatus = Geolocator.RequestAccessAsync();
        }

        private void ButtonRightImage_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CurImageIdx = (ViewModel.CurImageIdx + 1) % ViewModel.Restaurant.ImagePathLinkedList.Count;
            ViewModel.ImagePath = ViewModel.Restaurant.ImagePathLinkedList.ElementAt(ViewModel.CurImageIdx);
        }

        private void ButtonLeftImage_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CurImageIdx = (ViewModel.CurImageIdx - 1 + ViewModel.Restaurant.ImagePathLinkedList.Count) 
                                    % ViewModel.Restaurant.ImagePathLinkedList.Count;
            ViewModel.ImagePath = ViewModel.Restaurant.ImagePathLinkedList.ElementAt(ViewModel.CurImageIdx);
            
        }

        private void MapControlRestaurant_OnLoaded(object sender, RoutedEventArgs e)
        {
            MapControlRestaurant.Center = ViewModel.Restaurant.LocationGeopoint;
            MapControlRestaurant.ZoomLevel = 12;
        }

        private void calculateRestaurantRating(RestaurantSpec restaurantSpec)
        {
            double rating = 0;
            double cnt = 0;
            foreach (var it in DatabaseModel.CommentRestaurantsTable.Values)
            {
                if ((it.Restaurant.Id == restaurantSpec.Id))
                {
                    rating += it.Rating;
                    cnt++;
                }
            }

            if (cnt > 0)
            {
                rating /= cnt;
            }
            
            RestaurantSpec restaurant = DatabaseModel.RestaurantTable.First(x => x.Value.Id == restaurantSpec.Id).Value;
            restaurant.Rating = rating;
            restaurantSpec.Rating = restaurant.Rating;
        }

        private void ButtonAddComment_OnClick(object sender, RoutedEventArgs e)
        { 
            User user = DatabaseModel.UserTable.First(x=>x.Value.UserName == Navigation.Shell.Model.UserName).Value;
            CommentRestaurant commentRestaurant = new CommentRestaurant(TextBoxComment.Text, (int)SliderRating.Value, user, ViewModel.Restaurant);
            ViewModel.CommentRestaurants.Add(commentRestaurant);
            DatabaseModel.CommentRestaurantsTable.Add(commentRestaurant.Id, commentRestaurant);
            calculateRestaurantRating(ViewModel.Restaurant);
        }
    }
}
