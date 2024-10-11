using System.Globalization;
using System.Windows.Data;

namespace Converter.Converters
{
    internal class TimeSpanToEachTime : IValueConverter
    {
        private TimeSpan? _timeSpan;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan timeSpan)
            {
                _timeSpan ??= timeSpan;

                return parameter switch
                {
                    "Days" => timeSpan.Days,
                    "Hours" => timeSpan.Hours,
                    "Minutes" => timeSpan.Minutes,
                    _ => timeSpan
                };
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_timeSpan.HasValue && int.TryParse($"{value}", out int time))
            {
                return parameter switch
                {
                    "Days" => new TimeSpan(time, _timeSpan.Value.Hours, _timeSpan.Value.Minutes, _timeSpan.Value.Seconds),
                    "Hours" => new TimeSpan(_timeSpan.Value.Days, time, _timeSpan.Value.Minutes, _timeSpan.Value.Seconds),
                    "Minutes" => new TimeSpan(_timeSpan.Value.Days, _timeSpan.Value.Hours, time, _timeSpan.Value.Seconds),
                    _ => _timeSpan.Value
                };
            }

            return Binding.DoNothing;
        }
    }
}