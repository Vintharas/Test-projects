using System;
using System.Windows;
using System.Windows.Controls;

namespace Chapter2_BasicWPFAppPlainCSharp
{
    class MyWindow : Window
    {
        public MyWindow()
        {
            Width = 300;
            Height = 200;
            Title = "My simple window";
            
            Button btn = new Button();
            btn.Content = "Click Me!";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Content = btn;
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Example 1.
            //Window myWindow = new Window();
            //myWindow.Title = "My Simple Window";
            //myWindow.Content = "Hi there!";

            //Application myApplication = new Application();
            //myApplication.Run(myWindow);


            // Example 2.
            MyWindow myWindow = new MyWindow();
            myWindow.Show();
            Application app = new Application();
            app.Run();
        }
    }
}
