using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.Logic.Params
{
    public class MealInfoParams : AbstractParams
    {
        private Meal meal;

        public Meal Meal
        {
            get => meal;
            set => meal = value;
        }

        public MealInfoParams(Meal meal)
        {
            this.meal = meal;
        }
    }
}
