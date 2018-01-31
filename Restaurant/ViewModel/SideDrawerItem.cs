using System;
using System.Windows.Input;

namespace Restaurant.ViewModel
{
    class SideDrawerItem
    {
        private Type navigationDestination;
        private string name;
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
    }
}