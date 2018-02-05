namespace Restaurant.Model.Tables
{
    public class CommentMeal
    {
        private string comment;
        private static int ID_COMMENT_MEAL = 0;
        private User user;
        private Meal meal;
        private int rating;
        private int id;

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

        public Meal Meal
        {
            get => meal;
            set => meal = value;
        }

        public int Rating
        {
            get => rating;
            set => rating = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public CommentMeal(string comment, User user, Meal meal, int rating)
        {
            this.comment = comment;
            this.user = user;
            this.meal = meal;
            this.rating = rating;
            this.id = ID_COMMENT_MEAL++;
        }
    }
}
