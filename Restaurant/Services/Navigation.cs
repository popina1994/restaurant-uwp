using System;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Restaurant.Services
{
    public static class Navigation
    {
        private static Frame frame;

        public static Frame Frame
        {
            get { return frame; }
            set { frame = value; }
        }

        public static void Navigate(Type sourcePageType)
        {
            if (frame.CurrentSourcePageType != sourcePageType)
            {
                frame.Navigate(sourcePageType);
            }
        }
    }
}