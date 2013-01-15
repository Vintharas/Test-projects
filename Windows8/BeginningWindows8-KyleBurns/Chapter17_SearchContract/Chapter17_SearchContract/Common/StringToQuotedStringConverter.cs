using System;
using Windows.UI.Xaml.Data;

namespace Chapter17_SearchContract.Common
{
    public class StringToQuotedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //this.DefaultViewModel["QueryText"] = '\u201c' + queryText + '\u201d';
            var unquotedString = value as string;
            return '\u201c' + unquotedString + '\u201d';
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var quotedString = value as string;
            return quotedString.Replace("\u201c", "").Replace("\u201d", "");
        }
    }
}