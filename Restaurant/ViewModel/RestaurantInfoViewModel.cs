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
    public class RestaurantInfoViewModel : INotifyPropertyChanged
    {
        private RestaurantSpec restaurant;
        private string imagePath;
        private int curImageIdx;
        private bool canAddComments;
        private bool isOrder;
        private ObservableCollection<CommentRestaurant> commentRestaurants;
        private Dictionary<int, Meal> meals;

        public bool CanAddComments
        {
            get => canAddComments;
            set => canAddComments = value;
        }

        public bool IsOrder
        {
            get => isOrder;
            set => isOrder = value;
        }

        public Dictionary<int, Meal> Meals
        {
            get => meals;
            set => meals = value;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RestaurantSpec Restaurant
        {
            get => restaurant;
            set { restaurant = value; this.OnPropertyChanged();}
        }

        public RestaurantInfoViewModel(RestaurantSpec restaurant)
        {
            this.restaurant = restaurant;
        }

        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                this.OnPropertyChanged();
            }
        }

        public int CurImageIdx
        {
            get => curImageIdx;
            set => curImageIdx = value;
        }

        public ObservableCollection<CommentRestaurant> CommentRestaurants
        {
            get => commentRestaurants;
            set => commentRestaurants = value;
        }
    }
}
