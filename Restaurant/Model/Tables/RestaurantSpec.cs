using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Tables
{

    public class RestaurantSpec
    {
        private static int ID_RESTAURANT_GENERATED = 0;
        private int id;
        private string name;
        private string address;
        private int rating;
        private LinkedList<string> imagePathLinkedList;
        private string kitchen;
        private string description;
        private bool canVisa;
        private bool canCash;
        private bool canMasterCard;
        private bool canPayPal;



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

        public int Rating
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

        public RestaurantSpec(string name, string address, int rating, LinkedList<string> imagePathLinkedList, string kitchen, string description, bool canCash, bool canMasterCard, bool canPayPal, bool canVisa)
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
    }
}
