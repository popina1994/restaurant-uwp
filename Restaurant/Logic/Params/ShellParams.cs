using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.Logic.Params
{
    class ShellParams : AbstractParams
    {
        private User user;

        public ShellParams(User user)
        {
            this.user = user;
        }

        public User User
        {
            get => user;
            set => user = value;
        }
    }
}
