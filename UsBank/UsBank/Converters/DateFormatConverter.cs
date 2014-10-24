using System;
using Windows.UI.Xaml.Data;

namespace UsBank.Converters
{
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = DateTime.Parse(value as string);            
            return date.ToString("dd/mm/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
