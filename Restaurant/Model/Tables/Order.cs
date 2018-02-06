using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Restaurant.Model.Tables
{
    public class Order : INotifyPropertyChanged
    {
        private static int ID_ORDER = 0;
        private int id;
        private User user;
        private Dictionary<int, OrderMealOption> orderMealOptions;
        private int amount;
        private string status;
        private string paidBy;

        private string dateTimeOrdered;
        private string dateTimeDelivered;

        private static readonly SolidColorBrush[] GROUPS_COLOURS =
        {
            new SolidColorBrush(Color.FromArgb(255, 0, 255, 0)),
            new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)),
            new SolidColorBrush(Color.FromArgb(255, 0, 0, 255)),
            new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)),
            new SolidColorBrush(Color.FromArgb(127, 255, 255, 255))

        };

        private static readonly string[] GROUPS_COLOURS_STR =
        {
            "Green", "Yellow", "Blue", "Red", "Gray"
        };


        private int group;
        private static string DELIVERED = "ИСПОРУЧЕНО";
        private static string CANCELED = "ОТКАЗАНО";
        private static string NOT_DELIVERED = "У ПУТУ";

        private static string PAID_PAY_PAL = "PayPal-ом";
        private static string PAID_VISA = "Visa-ом";
        private static string PAID_MASTER= "Master Card-ом";
        private static string PAID_CASH = "Кешом";

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

        public User User
        {
            get => user;
            set => user = value;
        }

        public Dictionary<int, OrderMealOption> OrderMealOptions
        {
            get => orderMealOptions;
            set => orderMealOptions = value;
        }

        public static string[] GroupsColoursStr => GROUPS_COLOURS_STR;

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public string Status
        {
            get => status;
            set
            {
                status = value;
                this.OnPropertyChanged();
            }
        }

        public string PaidBy
        {
            get => paidBy;
            set => paidBy = value;
        }

        public static string PaidPayPal
        {
            get => PAID_PAY_PAL;
            set => PAID_PAY_PAL = value;
        }

        public static string PaidVisa
        {
            get => PAID_VISA;
            set => PAID_VISA = value;
        }

        public static string PaidMaster
        {
            get => PAID_MASTER;
            set => PAID_MASTER = value;
        }

        public static string PaidCash
        {
            get => PAID_CASH;
            set => PAID_CASH = value;
        }



        public static string Delivered => DELIVERED;

        public static string Canceled => CANCELED;

        public static string NotDelivered => NOT_DELIVERED;

        public string DateTimeOrdered
        {
            get => dateTimeOrdered;
            set => dateTimeOrdered = value;
        }

        public string DateTimeDelivered
        {
            get => dateTimeDelivered;
            set => dateTimeDelivered = value;
        }


        public static SolidColorBrush[] GroupsColours => GROUPS_COLOURS;

        public int Group
        {
            get => group;
            set { group = value; this.OnPropertyChanged();}
        }


        public Order(User user, Dictionary<int, OrderMealOption> orderMealOptions, int amount, string status, string paidBy, string dateTimeOrdered, string dateTimeDelivered, int group)
        {
            this.id = ID_ORDER++;
            this.user = user;
            this.orderMealOptions = orderMealOptions;
            this.amount = amount;
            this.status = status;
            this.paidBy = paidBy;
            this.dateTimeDelivered = dateTimeDelivered;
            this.dateTimeOrdered = dateTimeOrdered;
            this.group = group;
        }
    }
}
