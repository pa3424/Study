using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Converter.Converters
{
    internal class BoolToColor_ThreeColor : BoolToColor
    {
        public SolidColorBrush WhenNull { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (bool?)value switch
                {
                    true => WhenTrue,
                    false => WhenFalse,
                    _ => WhenNull,
                };
            }
            catch
            {
                return Binding.DoNothing;
            }
        }
    }
}