using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Clarika.Examen.Tecnico.Converters
{
    public class FirstLetterConvert : IValueConverter
    {
     

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var word = (string)value;
            return !string.IsNullOrEmpty(word) ? word[0].ToString() : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
