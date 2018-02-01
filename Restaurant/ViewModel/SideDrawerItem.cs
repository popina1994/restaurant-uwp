using System;
using System.Windows.Input;

namespace Restaurant.ViewModel
{
    class SideDrawerItem
    {
        private Type navigationDestination;
        private Type navigationDestinationMobile;
        private string name;
        public Type NavigationDestination
        {
            get { return navigationDestination; } 
            set { navigationDestination = value; }
        }

        public Type NavigationDestinationMobile
        {
            get { return navigationDestinationMobile;  }
            set { navigationDestinationMobile = value;  }
        }

        public string Name
        {
            get { return name; }
            set { name = value;  }
        }
    }
}