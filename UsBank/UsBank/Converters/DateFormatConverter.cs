using System;
using Windows.UI.Xaml.Data;

namespace UsBank.Converters
{
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date;
            DateTime.TryParse(value as string, out date);
            if (date != null)
            {
                return date.ToString("dd/mm/yyyy");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
