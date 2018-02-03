using System;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Restaurant.Logic.Params;

namespace Restaurant.Services
{
    public static class Navigation
    {
        private static Frame frame;
        private static Shell shell;
        private static readonly EventHandler<BackRequestedEventArgs> GoBackHandler = (s, e) => Navigation.GoBack();
        private static readonly EventHandler<BackPressedEventArgs> GoBackPhoneHandler = (s, e) => Navigation.GoBack(e);

        public static Frame Frame
        {
            get { return frame; }
            set { frame = value; }
        }

        public static Shell Shell
        {
            get => shell;
            set => shell = value;
        }

        public static void Navigate(Type sourcePageType, AbstractParams abstractParams = null)
        {
            if (frame.CurrentSourcePageType != sourcePageType)
            {
                frame.Navigate(sourcePageType, abstractParams);
            }
        }

        public static void EnableBackButton()
        {
            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                HardwareButtons.BackPressed -= GoBackPhoneHandler;
                HardwareButtons.BackPressed += GoBackPhoneHandler;

                return;
            }

            var navManager = SystemNavigationManager.GetForCurrentView();
            navManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            navManager.BackRequested -= GoBackHandler;
            navManager.BackRequested += GoBackHandler;
        }   

        public static void GoBack()
        {
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public static void GoBack(BackPressedEventArgs e)
        {
            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
        }
    }
}