using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.Logic.Params
{
    class OrderInfoParams : AbstractParams
    {
        private Order order;

        public Order Order
        {
            get => order;
            set => order = value;
        }

        public OrderInfoParams(Order order)
        {
            this.order = order;
        }
    }
}
