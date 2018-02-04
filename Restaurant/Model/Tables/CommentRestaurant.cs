using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Tables
{
    public class CommentRestaurant
    {
        private string comment;
        private static int ID_COMMENT_RESTAURANT = 0;
        private User user;
        private RestaurantSpec restaurant;
        private int rating;
        private int id;

        public CommentRestaurant(string comment, int rating, User user, RestaurantSpec restaurant)
        {
            this.id = ID_COMMENT_RESTAURANT++;
            this.comment = comment;
            this.user = user;
            this.restaurant = restaurant;
            this.rating = rating;
        }

        public string Comment
        {
            get => comment;
            set => comment = value;
        }

        public User User
        {
            get => user;
            set => user = value;
        }

        public RestaurantSpec Restaurant
        {
            get => restaurant;
            set => restaurant = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Rating
        {
            get => rating;
            set => rating = value;
        }
    }
}
