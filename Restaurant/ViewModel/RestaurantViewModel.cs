using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.ViewModel
{
    public class RestaurantViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<RestaurantSpec> restaurants;
        private ObservableCollection<Meal> meals;
        private ObservableCollection<Order> orders;
        private string selectedPivot;
        private Order selectedOrder;
        private bool isOrderer;
        private bool isDeliverer;
        private bool isUnregistered;

        private bool isSearchRestaurantShown = false;
        private bool isSearchMealShown = false;
        private bool isSearchOrderShown = false;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<RestaurantSpec> Restaurants
        {
            get => restaurants;
            set => restaurants = value;
        }

        public Order SelectedOrder
        {
            get => selectedOrder;
            set => selectedOrder = value;
        }

        public RestaurantViewModel(ObservableCollection<RestaurantSpec> restaurants, ObservableCollection<Meal> meals, ObservableCollection<Order> orders)
        {
            this.restaurants = restaurants;
            this.meals = meals;
            this.orders = orders;
        }


        public ObservableCollection<Meal> Meals
        {
            get => meals;
            set => meals = value;
        }


        public string SelectedPivot
        {
            get => selectedPivot;
            set => selectedPivot = value;
        }

        public bool IsSearchRestaurantShown
        {
            get => isSearchRestaurantShown;
            set
            {
                isSearchRestaurantShown = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Order> Orders
        {
            get => orders;
            set => orders = value;
        }

        public bool IsOrderer
        {
            get => isOrderer;
            set => isOrderer = value;
        }

        public bool IsDeliverer
        {
            get => isDeliverer;
            set => isDeliverer = value;
        }

        public bool IsUnregistered
        {
            get => isUnregistered;
            set => isUnregistered = value;
        }

        public bool IsSearchMealShown
        {
            get => isSearchMealShown;
            set
            {
                isSearchMealShown = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsSearchOrderShown
        {
            get => isSearchOrderShown;
            set { isSearchOrderShown = value; this.OnPropertyChanged();}
        }
    }
}
