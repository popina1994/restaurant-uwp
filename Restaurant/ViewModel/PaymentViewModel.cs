using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModel
{
    public class PaymentViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool notPaid = true;

        private int price;

        public int Price
        {
            get => price;
            set { price = value;  this.OnPropertyChanged();}
        }

        public PaymentViewModel(int price)
        {
            this.price = price;
        }

        public bool NotPaid
        {
            get => notPaid;
            set { notPaid = value; this.OnPropertyChanged(); } 
        }
    }
}
