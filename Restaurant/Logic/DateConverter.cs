using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;



namespace Restaurant.Logic
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTime)
            {
                DateTime item = (DateTime) value;
     
                if (item != null)
                {
                    if (item.Year == 1)
                    {
                        return "";
                    }
                    return item.ToString("dd-MM-yyyy");
                }
                
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
