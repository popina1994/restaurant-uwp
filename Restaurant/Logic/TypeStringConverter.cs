using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Restaurant.Model.Tables;

namespace Restaurant.Logic
{
    class TypeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
            {
                int val = (int) value;
                switch (val)
                {
                    case User.TYPE_ORDERER:
                        return "    Поручилац";
                    case User.TYPE_DELIVERER:
                        return "    Достављач";

                }
                
            }

            return "    Нерегистровани";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
