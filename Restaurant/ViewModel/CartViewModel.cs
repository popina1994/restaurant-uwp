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
    public class CartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meal> meals;
        private bool hasOrders;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Meal> Meals
        {
            get => meals;
            set => meals = value;
        }

        public CartViewModel(ObservableCollection<Meal> meals)
        {
            this.meals = meals;
        }

        public bool HasOrders
        {
            get => hasOrders;
            set { hasOrders = value;  this.OnPropertyChanged();}
        }
    }
}
