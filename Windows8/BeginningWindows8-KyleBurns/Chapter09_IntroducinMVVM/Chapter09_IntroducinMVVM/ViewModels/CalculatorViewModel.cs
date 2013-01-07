using System.Windows.Input;
using Chapter09_IntroducinMVVM.Common;

namespace Chapter09_IntroducinMVVM.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private int? firstOperand;
        public int? FirstOperand
        {
            get { return firstOperand; }
            set { SetProperty(ref firstOperand, value); }
        }
        
        private int? secondOperand;
        public int? SecondOperand
        {
            get { return secondOperand; }
            set { SetProperty(ref secondOperand, value); }
        }
        
        private int? result;
        public int? Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        
        public CalculatorViewModel()
        {
            AddCommand = new DelegateCommand(
                executeAction: x => { Result = FirstOperand.Value + SecondOperand.Value; },
                canExecutePredicate: x => FirstOperand.HasValue && SecondOperand.HasValue);
            ClearCommand = new DelegateCommand(
                executeAction: x =>
                    {
                        FirstOperand = null;
                        SecondOperand = null;
                        Result = null;
                    },
                canExecutePredicate: x => true);
            // Ensure than whenever a property changes we check if we can execute the Add command
            PropertyChanged += (sender, args) => ((DelegateCommand) AddCommand).RaiseCanExecuteChanged();
        } 
    }
}