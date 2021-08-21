using System;
using System.Windows.Input;
using System.Collections.Generic;
namespace WPF_0815
{
    class RelayCommand : ICommand
    {
        private Action<object> _action;
        List<KeyValuePair<string, int>> btnCnt;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }
        #region ICommand Members
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _action(parameter);
        }
        #endregion
    }
}
