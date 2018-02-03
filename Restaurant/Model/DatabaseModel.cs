using Restaurant.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class DatabaseModel
    {
        private static Dictionary<int, User> userTable;
        private static KeyValuePair<int, User> userTableDefault;

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

        private static void initUserTable()
        {
            userTableDefault = default(KeyValuePair<int, User>);
            User user1 = new User("popina", "1", User.TYPE_DELIVERER, "Ђорђе", "Живановић", "111-111-111", "Лопатањ б.б.",
                "djordj@djordje.com");
            User user2 = new User("popina1", "1", User.TYPE_ORDERER, "Marko", "Markovic", "111-111-111", "Лопатањ б.б.",
                "marko@marko.com");

            userTable = new Dictionary<int, User> {{user1.Id, user1}, {user2.Id, user2}};
        }
        

        static DatabaseModel()
        {
            initUserTable();
        }

        
    }
}
