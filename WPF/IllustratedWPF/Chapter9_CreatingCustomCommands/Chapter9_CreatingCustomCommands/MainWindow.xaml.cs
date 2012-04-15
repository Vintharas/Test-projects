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

namespace Chapter9_CreatingCustomCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Bind reverse command
            btnReverse.Command = ReverseCommand.Reverse;
            CommandBinding binding = new CommandBinding();
            binding.Command = ReverseCommand.Reverse;
            binding.Executed += ReverseString_Executed;
            binding.CanExecute += ReverseString_CanExecute;
            // Note how the binding is added to the CommandBindings collection of the MainWindow
            // When the command is executed, the Executed event is raised and the event is routed up the tree
            // until it gets to the window level
            CommandBindings.Add(binding);
        }

        /// <summary>
        /// Reverse the string in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseString_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string theString = txtBox.Text;
            txtBox.Text = string.Join("", theString.Reverse());
        }

        /// <summary>
        /// Check whether there is a string in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseString_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtBox.Text.Length > 0;
        }
    }
}
