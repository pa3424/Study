using System.Globalization;
using System.Windows.Data;

namespace Converter.Converters
{
    internal class BoolToString : IValueConverter
    {
        public string WhenTrue { get; set; }
        public string WhenFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (bool)value ? WhenTrue : WhenFalse;
            }
            catch
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => default;
    }
}