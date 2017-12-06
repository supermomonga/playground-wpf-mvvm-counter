using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OkaneHoshii
{
    public class DelegateCommand : ICommand
    {
        Func<Task> _ExecuteAsync;
        Func<bool> _CanExecute;

        public bool CanExecute(object parameter)
        {
            return _CanExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public async void Execute(object parameter)
        {
            await _ExecuteAsync();
        }

        public DelegateCommand(Func<Task> executeAsync, Func<bool> canExecute)
        {
            _ExecuteAsync = executeAsync;
            _CanExecute = canExecute;
        }
    }
}
