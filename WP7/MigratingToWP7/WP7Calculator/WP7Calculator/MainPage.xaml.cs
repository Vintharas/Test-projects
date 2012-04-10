using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WP7Calculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private OperatorTypes currentOperation = OperatorTypes.None;
        private bool isNewNumber = false;
        private IList<double> operands = new List<double>();

        /// <summary>
        /// Dependency property that represents the number to display in the calculator.
        /// DisplayNumber is required to be dependency property so we can use it for databinding purposes
        /// </summary>
        public static readonly DependencyProperty DisplayNumberProperty = DependencyProperty.Register("DisplayNumber", typeof(double), typeof(MainPage), null);
        public double DisplayNumber
        {
            get { return (double) GetValue(DisplayNumberProperty); }
            set { SetValue(DisplayNumberProperty, value);}
        }


        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle the OnNavigatedTo event that is triggered every time the user navigates to the page
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            DataContext = this;
            DisplayNumber = 0;
        }

        /// <summary>
        /// Handle the click event on the clear button. Clear the display number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber = 0;
            operands.Clear();
        }

        /// <summary>
        /// Handle click event on any button that has a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            double buttonNumber = double.Parse(((Button) sender).Content.ToString());
            AddToDisplayNumber(buttonNumber);
        }

        /// <summary>
        /// Handle click event on the addition button to perform an addition operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = OperatorTypes.Addition;
            isNewNumber = true;
        }

        /// <summary>
        /// Handle click event on the substraction button to perform an substraction operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = OperatorTypes.Subtraction;
            isNewNumber = true;
        }

        /// <summary>
        /// Handle click event on the multiplication button to perform an multiplication operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = OperatorTypes.Multiplication;
            isNewNumber = true;
        }

        /// <summary>
        /// Handle click event on the division button to perform an division operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = OperatorTypes.Division;
            isNewNumber = true;
        }

        /// <summary>
        /// Handle click event on the equals button to perform the operation in course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            operands.Add(DisplayNumber);
            switch (currentOperation)
            {
                case OperatorTypes.Addition:
                    DisplayNumber = SumOperands();
                    break;
                case OperatorTypes.Subtraction:
                    DisplayNumber = SubstractOperands();
                    break;
                case OperatorTypes.Multiplication:
                    DisplayNumber = MultiplyOperands();
                    break;
                case OperatorTypes.Division:
                    DisplayNumber = DivideOperands();
                    break;
                default:
                    break;
            }
            isNewNumber = true;
            currentOperation = OperatorTypes.None;
            operands.Clear();
        }

        private double SumOperands()
        {
            return operands.Sum();
        }

        private double SubstractOperands()
        {
            double result = operands.First();
            return operands.Skip(1).Aggregate(result, (current, operand) => current - operand);
        }

        private double MultiplyOperands()
        {
            double result = 1;
            return operands.Aggregate(result, (current, operand) => current * operand);
        }

        private double DivideOperands()
        {
            double result = operands.First();
            return operands.Skip(1).Aggregate(result, (current, operand) => current/ operand);
        }

        private void AddToDisplayNumber(double digit)
        {
            if (isNewNumber)
            {
                isNewNumber = false;
                operands.Add(DisplayNumber);
                DisplayNumber = digit;
            }
            else if (DisplayNumber == 0)
                DisplayNumber = digit;
            else
                DisplayNumber = DisplayNumber*10 + digit;
        }
    }
}