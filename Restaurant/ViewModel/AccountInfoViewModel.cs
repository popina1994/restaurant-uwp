using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.ViewModel
{
    public class AccountInfoViewModel
    {
        private User user;

        public User User
        {
            get => user;
            set => user = value;
        }

        public AccountInfoViewModel(User user)
        {
            this.user = user;
        }
    }
}
