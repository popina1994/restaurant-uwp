using Restaurant.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
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

        private static Dictionary<int, CommentMeal> commentMealTable;
        private static KeyValuePair<int, CommentMeal> commentMealTableDefault;

        private static Dictionary<int, OrderMealOption> orderMealOptionsTable;
        private static KeyValuePair<int, OrderMealOption> orderMealOptionsTableDefault;

        private static Dictionary<int, Order> ordersTable;
        private static KeyValuePair<int, Order> ordersDefault;


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


        public static Dictionary<int, CommentMeal> CommentMealTable
        {
            get => commentMealTable;
            set => commentMealTable = value;
        }

        public static KeyValuePair<int, CommentMeal> CommentMealTableDefault
        {
            get => commentMealTableDefault;
            set => commentMealTableDefault = value;
        }

        public static Dictionary<int, OrderMealOption> OrderMealOptionsTable
        {
            get => orderMealOptionsTable;
            set => orderMealOptionsTable = value;
        }

        public static KeyValuePair<int, OrderMealOption> OrderMealOptionsTableDefault
        {
            get => orderMealOptionsTableDefault;
            set => orderMealOptionsTableDefault = value;
        }

        public static Dictionary<int, Order> OrdersTable
        {
            get => ordersTable;
            set => ordersTable = value;
        }

        public static KeyValuePair<int, Order> OrdersDefault
        {
            get => ordersDefault;
            set => ordersDefault = value;
        }

        public static User UnregisteredUser
        {
            get => UNREGISTERED_USER;
            set => UNREGISTERED_USER = value;
        }

        private static User UNREGISTERED_USER;

        private static void initUserTable()
        {
            userTableDefault = default(KeyValuePair<int, User>);
            User user1 = new User("popina", "1", User.TYPE_DELIVERER, "Ђорђе", "Живановић", "111-111-111", "Лопатањ б.б.",
                "djordj@djordje.com");
            User user2 = new User("popina1", "1", User.TYPE_ORDERER, "Marko", "Markovic", "111-111-111", "Лопатањ б.б.",
                "marko@marko.com");
            UNREGISTERED_USER = new User("notregistered", "", User.TYPE_UNREGISTERED, "", "", "", "", "");

            userTable = new Dictionary<int, User> {{user1.Id, user1}, {user2.Id, user2}, { UNREGISTERED_USER.Id, UNREGISTERED_USER } };
        }
        

        private static void initRestaurantTable()
        {
            restaurantTableDefault = default(KeyValuePair<int, RestaurantSpec>);
            string RESTAURANT_PATH = "/Assets/Images/Restaurant/";
            Geopoint geopintKaraburma = new Geopoint(new BasicGeoposition() { Latitude = 44.8173, Longitude = 20.5096 });

            LinkedList<string> restaurant1ImagePath = new LinkedList<string>();
            restaurant1ImagePath.AddLast(RESTAURANT_PATH + "1.jpg");
            restaurant1ImagePath.AddLast(RESTAURANT_PATH + "2.jpg");
            RestaurantSpec restaurant1 = new RestaurantSpec("Карабурма", "Мије Ковачевића 7.б.", 5, restaurant1ImagePath, 
                                        "тајландска", "Кида", true, true, false, false, geopintKaraburma, "k1@k1.com", "011-000-000");

            LinkedList<string> restaurant2ImagePath = new LinkedList<string>();
            restaurant2ImagePath.AddLast(RESTAURANT_PATH + "3.jpg");
            restaurant2ImagePath.AddLast(RESTAURANT_PATH + "4.jpg");
            RestaurantSpec restaurant2 = new RestaurantSpec("Лола", "Мије Ковачевића 8.б", 4, restaurant2ImagePath, 
                                        "мексичка", "кида", false, false, true, true, geopintKaraburma, "k2@k2.com", "011-000-001");

            restaurantTable = new Dictionary<int, RestaurantSpec>{{restaurant1.Id, restaurant1}, {restaurant2.Id, restaurant2}};
        }
        private static void initMealsTable()
        {
            mealsTableDefault = default(KeyValuePair<int, Meal>);

            string MEALS_PATH = "/Assets/Images/Meals/";

            LinkedList<string> meal1ImagePath = new LinkedList<string>();
            meal1ImagePath.AddLast(MEALS_PATH + "Bean.jpg");
            Meal meal1 = new Meal("Пасуљ", 100, "Доручак", "Пасуљ, Бресква", "Врхунско", meal1ImagePath,
                RestaurantTable.First(x => x.Value.Id == 0).Value, 4);

            LinkedList<string> meal2ImagePath = new LinkedList<string>();
            meal2ImagePath.AddLast(MEALS_PATH + "Meat.jpg");
            Meal meal2 = new Meal("Месо", 200, "Ручак", "Коњ, кокошка", "Љуто", meal2ImagePath,
                RestaurantTable.First(x => x.Value.Id == 1).Value, 5);

            mealsTable = new Dictionary<int, Meal> { { meal1.Id, meal1 }, { meal2.Id, meal2 } };

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

        private static void initCommentMealsTable()
        {
            commentMealTableDefault = default(KeyValuePair<int, CommentMeal>);
            CommentMeal comment1 = new CommentMeal("Најбољи", UserTable.First(x => x.Value.Id == 1).Value,
                MealsTable.First(x => x.Value.Id == 0).Value, 5);
            CommentMeal comment2 = new CommentMeal("Онако", UserTable.First(x => x.Value.Id == 1).Value,
                MealsTable.First(x => x.Value.Id == 1).Value, 4);
            commentMealTable = new Dictionary<int, CommentMeal>() { { comment1.Id, comment1 }, { comment2.Id, comment2 } };
        }


        private static OrderMealOption orderMeal1;
        private static OrderMealOption orderMeal2;
        private static OrderMealOption orderMeal3;
        private static OrderMealOption orderMeal4;

        private static void initOrderMealsOptionTable()
        {
            orderMealOptionsTableDefault = default(KeyValuePair<int, OrderMealOption>);
            orderMeal1 = new OrderMealOption(MealsTable.First(x => x.Value.Id == 1).Value, 2, false);
            orderMeal2 = new OrderMealOption(MealsTable.First(x => x.Value.Id == 0).Value, 1, false);
            orderMeal4 = new OrderMealOption(MealsTable.First(x => x.Value.Id == 1).Value, 3, false);
            orderMeal3 = new OrderMealOption(MealsTable.First(x => x.Value.Id == 0).Value, 4, false);
            orderMealOptionsTable = new Dictionary<int, OrderMealOption>()
            {
                {orderMeal1.Id, orderMeal1}, {orderMeal2.Id, orderMeal2},
                {orderMeal3.Id, orderMeal3 }, {orderMeal4.Id, orderMeal4}
            };
        }

        private static void initOrdersTable()
        {
            ordersDefault = default(KeyValuePair<int, Order>);
            Order order1 = new Order(UserTable.First(x => x.Value.Id == 1).Value, new Dictionary<int, OrderMealOption>()
                { {orderMeal1.Id, orderMeal1}, {orderMeal2.Id, orderMeal2}}, orderMeal1.Amount * orderMeal1.Meal.Price + orderMeal2.Amount * orderMeal2.Meal.Price, 
                Order.NotDelivered, Order.PaidMaster, "11-11-2017", "");
            Order order2 = new Order(UserTable.First(x => x.Value.Id == 1).Value, new Dictionary<int, OrderMealOption>()
                    { {orderMeal3.Id, orderMeal3}, {orderMeal4.Id, orderMeal4}}, orderMeal3.Amount * orderMeal3.Meal.Price + orderMeal4.Amount * orderMeal4.Meal.Price, 
                Order.Delivered, Order.PaidVisa, "11-11-2017", "12-11-2017");
            ordersTable = new Dictionary<int, Order>() { { order1.Id, order1 }, { order2.Id, order2 } };
        }
    


        static DatabaseModel()
        {
            initUserTable();
            initRestaurantTable();
            initMealsTable();
            initCommentRestaurantTable();
            initCommentMealsTable();
            initOrderMealsOptionTable();
            initOrdersTable();
        }

        
    }
}
