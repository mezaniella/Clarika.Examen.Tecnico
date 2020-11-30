using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Clarika.Examen.Tecnico.Converters
{
    public class GenderConvert : IValueConverter
    {
        const string MALE = "Male";
        const string FEMALE = "Female";
        const string MALE_KEY = "M";
        const string FEMALE_KEY = "F";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = (string)value;

            if (gender == MALE_KEY)
                return MALE;

            if (gender == FEMALE_KEY)
                return FEMALE;

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
