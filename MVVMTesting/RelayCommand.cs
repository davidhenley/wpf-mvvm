using System;
using System.Windows.Input;

namespace MVVMTesting
{
    public class RelayCommand<T> : ICommand
    {
        Action<T> _executeMethod;
        Func<T, bool> _canExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod((T)parameter);
            }
            if (_executeMethod != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod((T)parameter);
            }
        }
    }

    public class RelayCommand : ICommand
    {
        Action _executeMethod;
        Func<bool> _canExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }
            if (_executeMethod != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }
    }
}