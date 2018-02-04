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
        private string selectedPivot;

        private bool isSearchRestaurantShown = false;

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

        public RestaurantViewModel(ObservableCollection<RestaurantSpec> restaurants, ObservableCollection<Meal> meals)
        {
            this.restaurants = restaurants;
            this.meals = meals;
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
    }
}
