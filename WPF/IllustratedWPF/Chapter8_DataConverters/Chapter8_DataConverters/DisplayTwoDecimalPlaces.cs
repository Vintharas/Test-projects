using System;
using System.Globalization;
using System.Windows.Data;

namespace Chapter8_DataConverters
{

    /// <summary>
    /// This Data Converter formats a double so it will only have two decimal digits
    /// </summary>
    [ValueConversion(sourceType: typeof(double), targetType: typeof(string))]
    public class DisplayTwoDecimalPlaces : IValueConverter
    {
        /// <summary>
        /// Convert value from source to target
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dValue = (double) value;
            return dValue.ToString("F2"); // F2 means {float}{two decimals}
        }

        /// <summary>
        /// Convert value from target to source
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dValue;
            double.TryParse((string) value, out dValue);
            return dValue;
        }
    }
}