using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Services;

namespace Restaurant.Model.Tables
{
    public class OrderMealOption : INotifyPropertyChanged
    {
        private int id;
        private static int ID_ORDER_MEAL_OPTION  = 0;
        private Meal meal;
        private int amount;
        private bool pickedUp;
        private bool isOrderer;
        private bool isDeliverer;

        public OrderMealOption(Meal meal, int amount, bool pickedUp)
        {
            this.id = ID_ORDER_MEAL_OPTION ++;
            this.meal = meal;
            this.amount = amount;
            this.pickedUp = pickedUp;
        }


        public bool IsOrderer
        {
            get => Navigation.Shell.Model.IsOrderer;
            set => isOrderer = value;
        }

        public bool IsDeliverer
        {
            get => Navigation.Shell.Model.IsDeliverer;
            set => isDeliverer = value;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public int Id
        {
            get => id;
            set => id = value;
        }

        public Meal Meal
        {
            get => meal;
            set => meal = value;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public bool PickedUp
        {
            get => pickedUp;
            set { pickedUp = value; this.OnPropertyChanged();}
        }
    }
}
