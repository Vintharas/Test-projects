using System;
using System.Windows.Input;

namespace Chapter09_IntroducinMVVM.ViewModels
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> executeAction;
        private readonly Func<object, bool> canExecutePredicate; 

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecutePredicate)
        {
            this.executeAction = executeAction;
            this.canExecutePredicate = canExecutePredicate;
        }

        public bool CanExecute(object parameter)
        {
            return canExecutePredicate(parameter);
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                throw new InvalidOperationException("Cannot execute now");
            executeAction(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

    }
}