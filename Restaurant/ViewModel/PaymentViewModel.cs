using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModel
{
    public class PaymentViewModel
    {
        private int price;

        public int Price
        {
            get => price;
            set => price = value;
        }

        public PaymentViewModel(int price)
        {
            this.price = price;
        }
    }
}
