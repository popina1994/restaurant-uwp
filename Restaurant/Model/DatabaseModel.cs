using Restaurant.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Notifications;

namespace Restaurant.Model
{
    class DatabaseModel
    {
        private static Dictionary<int, User> userTable;
        private static KeyValuePair<int, User> userTableDefault;
        private static Dictionary<int, RestaurantSpec> restaurantTable;
        private static KeyValuePair<int, RestaurantSpec> restaurantTableDefault;

        private static Dictionary<int, Meal> mealsTable;
        private static KeyValuePair<int, Meal> mealsTableDefault;

        private static Dictionary<int, CommentRestaurant> commentRestaurantsTable;
        private static KeyValuePair<int, CommentRestaurant> commentRestaurantTableDefault;

        public static Dictionary<int, User> UserTable
        {
            get => userTable;
            set => userTable = value;
        }

        public static KeyValuePair<int, User> UserTableDefault
        {
            get => userTableDefault;
            set => userTableDefault = value;
        }

        public static Dictionary<int, RestaurantSpec> RestaurantTable
        {
            get => restaurantTable;
            set => restaurantTable = value;
        }

        public static KeyValuePair<int, RestaurantSpec> RestaurantTableDefault
        {
            get => restaurantTableDefault;
            set => restaurantTableDefault = value;
        }

        public static Dictionary<int, Meal> MealsTable
        {
            get => mealsTable;
            set => mealsTable = value;
        }

        public static KeyValuePair<int, Meal> MealsTableDefault
        {
            get => mealsTableDefault;
            set => mealsTableDefault = value;
        }

        public static Dictionary<int, CommentRestaurant> CommentRestaurantsTable
        {
            get => commentRestaurantsTable;
            set => commentRestaurantsTable = value;
        }

        public static KeyValuePair<int, CommentRestaurant> CommentRestaurantTableDefault
        {
            get => commentRestaurantTableDefault;
            set => commentRestaurantTableDefault = value;
        }

        private static void initUserTable()
        {
            userTableDefault = default(KeyValuePair<int, User>);
            User user1 = new User("popina", "1", User.TYPE_DELIVERER, "Ђорђе", "Живановић", "111-111-111", "Лопатањ б.б.",
                "djordj@djordje.com");
            User user2 = new User("popina1", "1", User.TYPE_ORDERER, "Marko", "Markovic", "111-111-111", "Лопатањ б.б.",
                "marko@marko.com");

            userTable = new Dictionary<int, User> {{user1.Id, user1}, {user2.Id, user2}};
        }

        private static void initMealsTable()
        {
            mealsTableDefault = default(KeyValuePair<int, Meal>);

            string MEALS_PATH = "/Assets/Images/Meals/";

            LinkedList<string> meal1ImagePath = new LinkedList<string>();
            meal1ImagePath.AddLast(MEALS_PATH + "Bean.jpg");
            Meal meal1 = new Meal("Пасуљ", 100, "Доручак", "Пасуљ, Бресква", "Врхунско", meal1ImagePath,
                                RestaurantTable.First(x => x.Value.Id == 0).Value);

            LinkedList<string> meal2ImagePath = new LinkedList<string>();
            meal2ImagePath.AddLast(MEALS_PATH + "Meat.jpg");
            Meal meal2 = new Meal("Месо", 200,  "Ручак", "Коњ, кокошка", "Љуто", meal2ImagePath,
                                RestaurantTable.First(x => x.Value.Id == 0).Value);

            mealsTable = new Dictionary<int, Meal> { { meal1.Id, meal1 }, { meal2.Id, meal2} };

        }

        private static void initRestaurantTable()
        {
            restaurantTableDefault = default(KeyValuePair<int, RestaurantSpec>);
            string RESTAURANT_PATH = "/Assets/Images/Restaurant/";
            Geopoint geopintKaraburma = new Geopoint(new BasicGeoposition() { Latitude = 44.8173, Longitude = 20.5096 });

            LinkedList<string> restaurant1ImagePath = new LinkedList<string>();
            restaurant1ImagePath.AddLast(RESTAURANT_PATH + "1.jpg");
            restaurant1ImagePath.AddLast(RESTAURANT_PATH + "2.jpg");
            RestaurantSpec restaurant1 = new RestaurantSpec("Карабурма", "Мије Ковачевића 7.b.", 5, restaurant1ImagePath, 
                                        "тајландска", "Кида", true, true, false, false, geopintKaraburma, "k1@k1.com", "011-000-000");

            LinkedList<string> restaurant2ImagePath = new LinkedList<string>();
            restaurant2ImagePath.AddLast(RESTAURANT_PATH + "3.jpg");
            restaurant2ImagePath.AddLast(RESTAURANT_PATH + "4.jpg");
            RestaurantSpec restaurant2 = new RestaurantSpec("Карабурма 2", "Мије Ковачевића 8.b.", 4, restaurant2ImagePath, 
                                        "мексичка", "кида", false, false, true, true, geopintKaraburma, "k2@k2.com", "011-000-001");

            restaurantTable = new Dictionary<int, RestaurantSpec>{{restaurant1.Id, restaurant1}, {restaurant2.Id, restaurant2}};
        }

        private static void initCommentRestaurantTable()
        {
            commentRestaurantTableDefault = default(KeyValuePair<int, CommentRestaurant>);
            CommentRestaurant comment1 = new CommentRestaurant("Најбољи", 5, UserTable.First(x=>x.Value.Id == 1).Value, 
                                                                RestaurantTable.First(x=>x.Value.Id ==0).Value);
            CommentRestaurant comment2 = new CommentRestaurant("Онако", 4, UserTable.First(x => x.Value.Id == 1).Value,
                RestaurantTable.First(x => x.Value.Id == 1).Value);
            commentRestaurantsTable = new Dictionary<int, CommentRestaurant>(){{comment1.Id, comment1}, {comment2.Id, comment2}};
        }


        static DatabaseModel()
        {
            initUserTable();
            initRestaurantTable();
            initMealsTable();
            initCommentRestaurantTable();
        }

        
    }
}
