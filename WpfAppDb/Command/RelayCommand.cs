using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppDb.Command
{
    internal class RelayCommand<T> : ICommand
    {
        #region Event
        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Private Fields
        Action? _execute;
        Predicate<T>? _canExecute;
        #endregion

        #region Constructor
        public RelayCommand(Action? execute, Predicate<T>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region Methods
        public bool CanExecute(object? parameter)
        {
            if (_canExecute is null)
                return true;
            if (parameter is T typedParam)
                return _canExecute?.Invoke(typedParam) ?? true;
            else
                return false;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke();
        } 
        #endregion
    }
}
