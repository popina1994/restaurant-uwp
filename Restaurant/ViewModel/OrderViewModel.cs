using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.ViewModel
{
    public class OrderViewModel
    {
        private Order order;

        public Order Order
        {
            get => order;
            set => order = value;
        }

        public OrderViewModel()
        {
        }
    }
}
