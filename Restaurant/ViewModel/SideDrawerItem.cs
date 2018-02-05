using System;
using System.Windows.Input;

namespace Restaurant.ViewModel
{
    class SideDrawerItem
    {
        private Type navigationDestination;
        private string name;
        private bool registered;
        private bool isMenu;
        private bool orderer;

        private bool unregistered;
        private bool deliverer;

        public Type NavigationDestination
        {
            get { return navigationDestination; } 
            set { navigationDestination = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value;  }
        }

        public bool Registered
        {
            get { return registered;  }
            set { registered = value; }
        }

        public bool Unregistered
        {
            get { return unregistered; }
            set { unregistered = value; }
        }

        public bool IsMenu
        {
            get => isMenu;
            set => isMenu = value;
        }

        public bool Deliverer
        {
            get => deliverer;
            set => deliverer = value;
        }

        public bool Orderer
        {
            get => orderer;
            set => orderer = value;
        }
    }
}