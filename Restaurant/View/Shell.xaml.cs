using Restaurant.Services;
using Restaurant.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell
    {
        FrameworkElement selectedItem = null;
        bool isMenuSelected = false;
        bool isSettingsSelected = false;

        Dictionary <string, SideDrawerItem> sideDrawerItems = new Dictionary<string, SideDrawerItem>()
        {
            {"SideDrawerItemAccount", new SideDrawerItem(){ Name="SideDrawerItemAccount", NavigationDestination = typeof(AccountInfoPage)} },
            {"SideDrawerItemSettings", new SideDrawerItem(){ Name = "SideDrawerItemSettings", NavigationDestination = typeof(SettingsPage) } },
            {"SideDrawerItemHome", new SideDrawerItem(){ Name = "SideDrawerItemHome", NavigationDestination = typeof(HomePage)} },
            {"SideDrawerItemCart", new SideDrawerItem(){ Name = "SideDrawerItemCart", NavigationDestination = typeof(CartPage)} },
        };

        public Shell()
        {
            this.InitializeComponent();

            Navigation.Frame = SplitViewGlobalFrame;
            Navigation.Navigate(typeof(HomePage));
        }

        private void HamburgerButtonSelected()
        {
            SplitViewGlobal.IsPaneOpen = !SplitViewGlobal.IsPaneOpen;
            if (isMenuSelected)
            {
                ListViewMenu.SelectedItem = selectedItem;
            }
            else
            {
                ListViewMenu.SelectedItem = null;
            }
            if (isSettingsSelected)
            {
                ListViewSettings.SelectedItem = selectedItem;
            }
            else
            {
                ListViewSettings.SelectedItem = null;
            }

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                FrameworkElement selectedElement = e.AddedItems[0] as FrameworkElement;
                if (selectedElement.Name == "SideDrawerItemHamburger")
                {
                    HamburgerButtonSelected();
                    return;
                }
                selectedItem = selectedElement;
                if ((sender as ListView) == ListViewMenu)
                {
                    ListViewSettings.SelectedItem = null;
                    isSettingsSelected = false;
                    isMenuSelected = true;
                }
                else
                {
                    ListViewMenu.SelectedItem = null;
                    isSettingsSelected = true;
                    isMenuSelected = false;
                }
                SideDrawerItem item = sideDrawerItems.FirstOrDefault(x => x.Key == selectedElement.Name).Value;
                if (item != null)
                {
                    Navigation.Navigate(item.NavigationDestination);
                }

            }
        }

        private void SplitViewGlobalFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SplitViewGlobal.IsPaneOpen = false;
        }


    }
}
