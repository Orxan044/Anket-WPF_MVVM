using Anket_WPF_MVVM.Commands;
using Anket_WPF_MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Anket_WPF_MVVM.ViewModels;

public class AnketViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Person> _persons;
    public ObservableCollection<Person> Persons
    {
        get { return _persons; }
        set { _persons = value; OnPropertyChanged();}
    }
    private Person SelectedPerson { get; set; } 

    public RelayCommand ?AddPerson { get; set; }


    public AnketViewModel()
    {
        Persons = new();
        SelectedPerson = new();
        AddPerson = new RelayCommand(parameter =>
        {
            Persons.Add(SelectedPerson);
        });
    
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
