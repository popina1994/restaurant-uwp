using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Tables
{
    public class OrderMealOption
    {
        private int id;
        private static int ID_ORDER_MEAL_OPTION  = 0;
        private Meal meal;
        private int amount;
        private bool pickedUp;

        public OrderMealOption(Meal meal, int amount, bool pickedUp)
        {
            this.id = ID_ORDER_MEAL_OPTION ++;
            this.meal = meal;
            this.amount = amount;
            this.pickedUp = pickedUp;
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
            set => pickedUp = value;
        }
    }
}
