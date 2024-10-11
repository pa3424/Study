using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Converter.Converters
{
    internal class BoolToVisibility : IValueConverter
    {
        public Visibility WhenTrue { get; set; }
        public Visibility WhenFalse { get; set; }

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
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

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => default;
    }
}
