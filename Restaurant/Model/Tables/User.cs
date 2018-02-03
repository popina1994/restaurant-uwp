using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Restaurant.Model.Tables
{
    class User
    {
        private static int ID_USER_GENERATED = 0;
        public const int TYPE_ORDERER = 0;
        public const int TYPE_DELIVERER = 1;
        public const int TYPE_UNREGISTERED = 2;
        private int id;
        private int type;
        private string userName;
        private string password;
        private string firstName;
        private string lastName;
        private string phone;
        private string address;
        private string email;

        public int Type
        {
            get => type;
            set => type = value;
        }


        public int Id
        {
            get => id;
            set => id = value;
        }

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public User(string userName, string password, int type, string firstName, string lastName, string phone, string address, string email)
        {
            this.id = ID_USER_GENERATED ++;
            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.address = address;
            this.email = email;
            this.type = type;
        }
    }
}
