using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Converter.Converters
{
    internal class BoolToColor : IValueConverter
    {
        public SolidColorBrush WhenTrue { get; set; }
        public SolidColorBrush WhenFalse { get; set; }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
