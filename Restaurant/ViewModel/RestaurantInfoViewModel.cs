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
        private ObservableCollection<CommentRestaurant> commentRestaurants;

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
