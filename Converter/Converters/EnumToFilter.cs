using Converter.Models.Enum;
using System.Globalization;
using System.Windows.Data;

namespace Converter.Converters
{
    internal class EnumToFilter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Array enumValues)
            {
                var excludeValues = new[] { ETest.None, ETest.God };

                return enumValues.Cast<ETest>().Where(v => !excludeValues.Contains(v)).ToArray();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => default;
    }
}
