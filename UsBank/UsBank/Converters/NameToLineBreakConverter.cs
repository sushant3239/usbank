using System;
using Windows.UI.Xaml.Data;

namespace UsBank.Converters
{
    public class NameToLineBreakConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string name = value as string;
            if (!String.IsNullOrEmpty(name))
            {
                name = name.Replace(" ", "\n");
            }
            return name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
