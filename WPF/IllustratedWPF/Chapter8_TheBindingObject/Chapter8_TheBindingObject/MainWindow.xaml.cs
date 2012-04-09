using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chapter8_TheBindingObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Create binding programmatically
            Binding theBinding = new Binding();
            theBinding.Source = source;                     // the source of the binding is the "source" textbox
            theBinding.Path = new PropertyPath("Text");     // the path of the binding specifies with property within the source control to bind 

            // Connect the source and the target
            target.SetBinding(Label.ContentProperty, theBinding);   // notice how we bind a given source to a target dependency property
        }
    }
}
