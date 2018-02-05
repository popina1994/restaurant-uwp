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
    public class CartViewModel
    {
        private ObservableCollection<Meal> meals;
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
    }
}
