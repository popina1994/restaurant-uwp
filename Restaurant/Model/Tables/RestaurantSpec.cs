using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Restaurant.Model.Tables
{

    public class RestaurantSpec : INotifyPropertyChanged
    {
        private static int ID_RESTAURANT_GENERATED = 0;
        private int id;
        private string name;
        private string address;
        private double rating;
        private LinkedList<string> imagePathLinkedList;
        private string kitchen;
        private string description;
        private bool canVisa;
        private bool canCash;
        private bool canMasterCard;
        private bool canPayPal;
        private Geopoint locationGeopoint;
        private string phone;
        private string email;
        private TimeSpan monWorkingHoursStart;
        private TimeSpan tueWorkingHoursStart;
        private TimeSpan wedWorkingHoursStart;
        private TimeSpan thuWorkingHoursStart;
        private TimeSpan friWorkingHoursStart;
        private TimeSpan satWorkingHoursStart;
        private TimeSpan sunWorkingHoursStart;

        private TimeSpan monWorkingHoursEnd;
        private TimeSpan tueWorkingHoursEnd;
        private TimeSpan wedWorkingHoursEnd;
        private TimeSpan thuWorkingHoursEnd;
        private TimeSpan friWorkingHoursEnd;
        private TimeSpan satWorkingHoursEnd;
        private TimeSpan sunWorkingHoursEnd;

        private TimeSpan deliveryTime;


        private DateTime time = DateTime.Now;

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

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public double Rating
        {
            get => rating;
            set
            {
                rating = value;
                this.OnPropertyChanged();
            }
        }

        public LinkedList<string> ImagePathLinkedList
        {
            get => imagePathLinkedList;
            set => imagePathLinkedList = value;
        }

        public string Kitchen
        {
            get => kitchen;
            set => kitchen = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public DateTime Time
        {
            get => time;
            set => time = value;
        }

        public TimeSpan MonWorkingHoursStart
        {
            get => monWorkingHoursStart;
            set => monWorkingHoursStart = value;
        }

        public TimeSpan TueWorkingHoursStart
        {
            get => tueWorkingHoursStart;
            set => tueWorkingHoursStart = value;
        }

        public TimeSpan WedWorkingHoursStart
        {
            get => wedWorkingHoursStart;
            set => wedWorkingHoursStart = value;
        }

        public TimeSpan ThuWorkingHoursStart
        {
            get => thuWorkingHoursStart;
            set => thuWorkingHoursStart = value;
        }

        public TimeSpan FriWorkingHoursStart
        {
            get => friWorkingHoursStart;
            set => friWorkingHoursStart = value;
        }

        public TimeSpan SatWorkingHoursStart
        {
            get => satWorkingHoursStart;
            set => satWorkingHoursStart = value;
        }

        public TimeSpan SunWorkingHoursStart
        {
            get => sunWorkingHoursStart;
            set => sunWorkingHoursStart = value;
        }

        public TimeSpan MonWorkingHoursEnd
        {
            get => monWorkingHoursEnd;
            set => monWorkingHoursEnd = value;
        }

        public TimeSpan TueWorkingHoursEnd
        {
            get => tueWorkingHoursEnd;
            set => tueWorkingHoursEnd = value;
        }

        public TimeSpan WedWorkingHoursEnd
        {
            get => wedWorkingHoursEnd;
            set => wedWorkingHoursEnd = value;
        }

        public TimeSpan ThuWorkingHoursEnd
        {
            get => thuWorkingHoursEnd;
            set => thuWorkingHoursEnd = value;
        }

        public TimeSpan FriWorkingHoursEnd
        {
            get => friWorkingHoursEnd;
            set => friWorkingHoursEnd = value;
        }

        public TimeSpan SatWorkingHoursEnd
        {
            get => satWorkingHoursEnd;
            set => satWorkingHoursEnd = value;
        }

        public TimeSpan SunWorkingHoursEnd
        {
            get => sunWorkingHoursEnd;
            set => sunWorkingHoursEnd = value;
        }


        public TimeSpan DeliveryTime
        {
            get => deliveryTime;
            set => deliveryTime = value;
        }

        public RestaurantSpec(string name, string address, double rating, LinkedList<string> imagePathLinkedList, string kitchen, string description, bool canCash, bool canMasterCard, bool canPayPal, bool canVisa, Geopoint locationGeopoint, string email, string phone, 
                              TimeSpan monWorkingHoursStart, TimeSpan tueWorkingHoursStart, TimeSpan wedWorkingHoursStart, TimeSpan thuWorkingHoursStart, TimeSpan friWorkingHoursStart, TimeSpan satWorkingHoursStart, TimeSpan sunWorkingHoursStart,
                                TimeSpan monWorkingHoursEnd, TimeSpan tueWorkingHoursEnd, TimeSpan wedWorkingHoursEnd, TimeSpan thuWorkingHoursEnd, TimeSpan friWorkingHoursEnd, TimeSpan satWorkingHoursEnd, TimeSpan sunWorkingHoursEnd, TimeSpan deliveryTime)
        {
            this.id = ID_RESTAURANT_GENERATED++;
            this.name = name;
            this.address = address;
            this.rating = rating;
            this.imagePathLinkedList = imagePathLinkedList;
            this.kitchen = kitchen;
            this.description = description;
            this.canCash = canCash;
            this.canMasterCard = canMasterCard;
            this.canVisa = canVisa;
            this.canPayPal = canPayPal;
            this.locationGeopoint = locationGeopoint;
            this.phone = phone;
            this.email = email;
            this.monWorkingHoursStart = monWorkingHoursStart;
            this.tueWorkingHoursStart = tueWorkingHoursStart;
            this.wedWorkingHoursStart = wedWorkingHoursStart;
            this.thuWorkingHoursStart = thuWorkingHoursStart;
            this.friWorkingHoursStart = friWorkingHoursStart;
            this.satWorkingHoursStart = satWorkingHoursStart;
            this.sunWorkingHoursStart = sunWorkingHoursStart;

            this.monWorkingHoursEnd = monWorkingHoursEnd;
            this.tueWorkingHoursEnd = tueWorkingHoursEnd;
            this.wedWorkingHoursEnd = wedWorkingHoursEnd;
            this.thuWorkingHoursEnd = thuWorkingHoursEnd;
            this.friWorkingHoursEnd = friWorkingHoursEnd;
            this.satWorkingHoursEnd = satWorkingHoursEnd;
            this.sunWorkingHoursEnd = sunWorkingHoursEnd;

            this.deliveryTime = deliveryTime;
        }

        public bool CanVisa
        {
            get => canVisa;
            set => canVisa = value;
        }

        public bool CanCash
        {
            get => canCash;
            set => canCash = value;
        }

        public bool CanMasterCard
        {
            get => canMasterCard;
            set => canMasterCard = value;
        }

        public bool CanPayPal
        {
            get => canPayPal;
            set => canPayPal = value;
        }

        public Geopoint LocationGeopoint
        {
            get => locationGeopoint;
            set => locationGeopoint = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }
    }
}
