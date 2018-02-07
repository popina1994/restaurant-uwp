using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Services;

namespace Restaurant.Model.Tables
{
    public class Meal : INotifyPropertyChanged
    {
        private static int ID_MEALS_GENERATED = 0;
        private int id;
        private string name;
        private int price;
        private string category;
        private string ingridients;
        private string description;
        private LinkedList<string> imagePathLinkedList;
        private double rating;
        private int amount;
        private bool isOrderer;

        private RestaurantSpec restaurant;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsOrderer
        {
            get => Navigation.Shell.Model.IsOrderer;
            set => isOrderer = value;
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


        public int Price
        {
            get => price;
            set => price = value;
        }

        public string Category
        {
            get => category;
            set => category = value;
        }

        public string Ingridients
        {
            get => ingridients;
            set => ingridients = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public LinkedList<string> ImagePathLinkedList
        {
            get => imagePathLinkedList;
            set => imagePathLinkedList = value;
        }


        public Meal(string name, int price, string category, string ingridients, string description, LinkedList<string> imagePathLinkedList, RestaurantSpec restaurant, double rating)
        {
            this.id = ID_MEALS_GENERATED++;
            this.name = name;
            this.price = price;
            this.category = category;
            this.ingridients = ingridients;
            this.description = description;
            this.imagePathLinkedList = imagePathLinkedList;
            this.restaurant = restaurant;
            this.rating = rating;
            this.amount = 0;
        }

        public RestaurantSpec Restaurant
        {
            get => restaurant;
            set => restaurant = value;
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

        public int Amount
        {
            get => amount;
            set { amount = value; this.OnPropertyChanged();}
        }
    }
}
