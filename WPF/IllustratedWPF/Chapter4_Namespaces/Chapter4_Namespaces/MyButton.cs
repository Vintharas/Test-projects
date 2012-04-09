using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chapter4_Namespaces
{
    public class MyButton : Button
    {
        public MyButton()
        {
            Background = new LinearGradientBrush(Colors.White, Colors.Gray, new Point(0, 0), new Point(1, 1));
        }
         
    }
}