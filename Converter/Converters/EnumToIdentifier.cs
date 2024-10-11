using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace Converter.Converters
{
    internal class EnumToIdentifier : IValueConverter
    {
        private string GetEnumDescription(Enum enumObj)
        {
            FieldInfo? fieldInfo = enumObj.GetType().GetField($"{enumObj}");

            if (fieldInfo != null && fieldInfo.GetCustomAttributes(false).FirstOrDefault() is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return enumObj.ToString();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => GetEnumDescription((Enum)value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => default;
    }
}
