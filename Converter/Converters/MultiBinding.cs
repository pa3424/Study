using System.Globalization;
using System.Windows.Data;

namespace Converter.Converters
{
    internal class MultiBinding : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values.Clone();

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => default;
    }
}
