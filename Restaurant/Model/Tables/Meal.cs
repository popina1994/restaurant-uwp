using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Tables
{
    public class Meal
    {
        private static int ID_MEALS_GENERATED = 0;
        private int id;
        private string name;
        private int price;
        private string category;
        private string ingridients;
        private string description;
        private LinkedList<string> imagePathLinkedList;

        private RestaurantSpec restaurant;


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

        public Meal(string name, int price, string category, string ingridients, string description, LinkedList<string> imagePathLinkedList, RestaurantSpec restaurant)
        {
            this.id = ID_MEALS_GENERATED++;
            this.name = name;
            this.price = price;
            this.category = category;
            this.ingridients = ingridients;
            this.description = description;
            this.imagePathLinkedList = imagePathLinkedList;
            this.restaurant = Restaurant;
        }

        public RestaurantSpec Restaurant
        {
            get => restaurant;
            set => restaurant = value;
        }
    }
}
