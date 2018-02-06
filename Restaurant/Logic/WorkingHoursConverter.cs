using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Restaurant.Logic
{
    class WorkingHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TimeSpan)
            {
                TimeSpan timeSpan = (TimeSpan)value;
                if (timeSpan.Seconds == 1)
                {
                    return "НЕ РАДИ";
                }
                string val = timeSpan.ToString(@"hh\:mm");
                return val;
            }

            return "НЕ РАДИ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
