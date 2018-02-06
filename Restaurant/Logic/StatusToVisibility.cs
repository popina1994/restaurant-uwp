using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Restaurant.Model.Tables;
using Restaurant.Services;

namespace Restaurant.Logic
{
    public class StatusToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!Navigation.Shell.Model.IsDeliverer)
                return Visibility.Collapsed;
            if (value is string)
            {
                string str = value as string;
                if (str == Order.NotDelivered)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
