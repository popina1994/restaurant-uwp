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
using Restaurant.Logic.Params;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        FrameworkElement selectedItem = null;
        bool isMenuSelected = false;
        bool isSettingsSelected = false;

        Dictionary<string, SideDrawerItem> sideDrawerItems = new Dictionary<string, SideDrawerItem>()
        {
            {"SideDrawerItemAccount", new SideDrawerItem(){ Name="SideDrawerItemAccount", NavigationDestination = typeof(AccountInfoPage), Registered = true, Unregistered = true, IsMenu = false}},
            {"SideDrawerItemSettings", new SideDrawerItem(){ Name = "SideDrawerItemSettings", NavigationDestination = typeof(SettingsPage), Registered = true, Unregistered = true, IsMenu =  false} },
            {"SideDrawerItemHome", new SideDrawerItem(){ Name = "SideDrawerItemHome", NavigationDestination = typeof(HomePage), Registered = true, Unregistered = true, IsMenu = true}},
            {"SideDrawerItemCart", new SideDrawerItem(){ Name = "SideDrawerItemCart", NavigationDestination = typeof(CartPage), Registered = true, Unregistered = false, IsMenu = true}},
            {"SideDrawerItemRegister", new SideDrawerItem(){ Name = "SideDrawerItemRegister", NavigationDestination = typeof(RegisterPage), Registered = false, Unregistered = true, IsMenu = false}},
            {"SideDrawerItemLogin", new SideDrawerItem(){ Name = "SideDrawerItemLogin", NavigationDestination = typeof(LoginPage), Registered = false, Unregistered = true, IsMenu = false}}
        };

        public Shell()
        {
            if (Navigation.Shell == null)
            {
                Navigation.Shell = this;
            }

            this.InitializeComponent();
            this.Model = new ShellModel();

            Navigation.Frame = SplitViewGlobalFrame;
            Navigation.Navigate(typeof(HomePage));
        }

        public ShellModel Model { get; set; }

        private void undoSelect()
        {
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

        private void HamburgerButtonSelected()
        {
            SplitViewGlobal.IsPaneOpen = !SplitViewGlobal.IsPaneOpen;
            undoSelect();
        }

        private bool isMenuOptionAllowed(SideDrawerItem item)
        {
            if (item.Registered && Model.IsRegistered)
            {
                return true;
            }
            if (item.Unregistered && !Model.IsRegistered)
            {
                return true;
            }
            return false;
        }

        private void updateSideDrawer(FrameworkElement selectedElement, bool isMenu)
        {
            this.selectedItem = selectedElement;
            if (isMenu)
            {
                ListViewMenu.SelectedItem = selectedElement;
                ListViewSettings.SelectedItem = null;
                isSettingsSelected = false;
                isMenuSelected = true;
            }
            else
            {
                ListViewSettings.SelectedItem = selectedElement;
                ListViewMenu.SelectedItem = null;
                isSettingsSelected = true;
                isMenuSelected = false;
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

                SideDrawerItem item = sideDrawerItems.FirstOrDefault(x => x.Key == selectedElement.Name).Value;
                if (!isMenuOptionAllowed(item))
                {
                    undoSelect();
                    return;
                }
                
                if (item != null)
                {
                    Navigation.Navigate(item.NavigationDestination);
                }
            }
        }

        private void SplitViewGlobalFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (KeyValuePair<string, SideDrawerItem> it in sideDrawerItems)
            {
                if (it.Value.NavigationDestination == e.SourcePageType)
                {
                    FrameworkElement sideDrawerItem = (FrameworkElement)SplitViewGlobal.FindName(it.Value.Name);
                    updateSideDrawer(sideDrawerItem, it.Value.IsMenu);
                }
            }
            SplitViewGlobal.IsPaneOpen = false;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Navigation.EnableBackButton();
            base.OnNavigatedTo(e);
        }
    }
}
