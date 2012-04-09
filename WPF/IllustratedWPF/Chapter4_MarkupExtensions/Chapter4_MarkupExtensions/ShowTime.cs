using System;
using System.Windows.Markup;

namespace Chapter4_MarkupExtensions
{
    public class ShowTime : MarkupExtension
    {
        public string Header { get; set; }

        public ShowTime()
        {
            
        }

        public ShowTime(string header)
        {
            Header = header;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return string.Format("{0}: {1}", Header, DateTime.Now.ToLongTimeString());
        }
    }
}