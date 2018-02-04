using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.Logic.Params
{
    public class RestaurantInfoParams : AbstractParams
    {
        private RestaurantSpec restaurant;

        public RestaurantSpec Restaurant
        {
            get => restaurant;
            set => restaurant = value;
        }

        public RestaurantInfoParams(RestaurantSpec restaurant)
        {
            this.restaurant = restaurant;
        }
    }
}
