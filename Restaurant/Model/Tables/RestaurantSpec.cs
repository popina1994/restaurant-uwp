using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Restaurant.Model.Tables
{

    public class RestaurantSpec
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
            set => rating = value;
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

        public RestaurantSpec(string name, string address, double rating, LinkedList<string> imagePathLinkedList, string kitchen, string description, bool canCash, bool canMasterCard, bool canPayPal, bool canVisa, Geopoint locationGeopoint, string email, string phone)
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
