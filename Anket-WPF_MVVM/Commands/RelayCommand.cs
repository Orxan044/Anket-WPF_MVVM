using System.Windows.Input;

namespace Anket_WPF_MVVM.Commands;

public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    private readonly Predicate<object?>? _canExecute;
    private readonly Action<object?>? _execute;


<<<<<<< HEAD
    public RelayCommand(Action<object?>? execute , Predicate<object?>? canExecute = null)
=======
    public RelayCommand(Action<object?>? execute, Predicate<object?>? canExecute = null)
>>>>>>> c511e1b7491fafea2a5546e4a05376a315ad5ac9
    {
        _canExecute = canExecute;
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }

    public bool CanExecute(object? parameter) => _canExecute is null || _canExecute.Invoke(parameter);

    public void Execute(object? parameter)
    {
        _execute?.Invoke(parameter);
    }
}
