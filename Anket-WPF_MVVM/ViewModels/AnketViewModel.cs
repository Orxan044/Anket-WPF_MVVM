using Anket_WPF_MVVM.Commands;
using Anket_WPF_MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

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
        SelectedPerson = new()
        {
            Name = NewPersonName,
            Surname = NewPersonName,
            PhoneNumber = NewPersonPhoneNumber,
            Email = NewPersonEmail,
            Brithday = NewPersonBirthday

        };
        AddPerson = new RelayCommand(parameter =>
        {
            Persons.Add(SelectedPerson);
        });

    }

    private string? _newPersonName;
    public string? NewPersonName
    {
        get { return _newPersonName; }
        set
        {
            _newPersonName = value;
            OnPropertyChanged();
        }
    }

    private string? _newPersonSurname;
    public string? NewPersonSurname
    {
        get { return _newPersonSurname; }
        set
        {
            _newPersonSurname = value;
            OnPropertyChanged();
        }
    }

    private string? _newPersonPhoneNumber;
    public string? NewPersonPhoneNumber
    {
        get { return _newPersonPhoneNumber; }
        set
        {
            _newPersonPhoneNumber = value;
            OnPropertyChanged();
        }
    }

    private string? _newPersonEmail;
    public string? NewPersonEmail
    {
        get { return _newPersonEmail; }
        set
        {
            _newPersonEmail= value;
            OnPropertyChanged();
        }
    }

    private DateTime _newPersonBirthday = DateTime.Today;
    public DateTime NewPersonBirthday
    {
        get { return _newPersonBirthday; }
        set
        {
            _newPersonBirthday = value;
            OnPropertyChanged();
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    
}
