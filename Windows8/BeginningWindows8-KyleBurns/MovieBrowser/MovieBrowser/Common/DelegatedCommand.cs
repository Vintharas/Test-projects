using System;
using System.Windows.Input;

namespace MovieBrowser.Common
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecutePredicate;
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _executeAction = execute;
            _canExecutePredicate = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecutePredicate(parameter);
        }
        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                throw new InvalidOperationException("Cannot execute now");
            }
            _executeAction(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}