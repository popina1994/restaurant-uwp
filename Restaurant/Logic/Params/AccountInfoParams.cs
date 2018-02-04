using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.Logic.Params
{
    class AccountInfoParams : AbstractParams
    {
        private User user;

        public User User
        {
            get => user;
            set => user = value;
        }

        public AccountInfoParams(User user)
        {
            this.user = user;
        }
    }
}
