using Anket_WPF_MVVM.Commands;
using Anket_WPF_MVVM.Data;
using Anket_WPF_MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
<<<<<<< HEAD
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
=======
using System.Runtime.CompilerServices;
using System.Xml.Linq;
>>>>>>> c511e1b7491fafea2a5546e4a05376a315ad5ac9

namespace Anket_WPF_MVVM.ViewModels;

public class AnketViewModel : INotifyPropertyChanged
{
<<<<<<< HEAD
    private Person newPerson;
    private Person selectedPerson;
    private string? fileName;

    public string? FileName { get => fileName; set { fileName = value; OnPropertyChanged(); } }
    public AppDbContext DbContext { get; set; }

    public Person NewPerson { get => newPerson; set { newPerson = value; OnPropertyChanged(); } }
    public Person SelectedPerson { get => selectedPerson; set { selectedPerson = value; OnPropertyChanged(); } }

    public RelayCommand AddCommand { get; set; }

    public RelayCommand SaveCommand { get; set; }
    public RelayCommand LoadCommand { get; set; }
=======
    private ObservableCollection<Person> _persons;
    public ObservableCollection<Person> Persons
    {
        get { return _persons; }
        set { _persons = value; OnPropertyChanged();}
    }
    private Person SelectedPerson { get; set; } 
>>>>>>> c511e1b7491fafea2a5546e4a05376a315ad5ac9

    public RelayCommand ?AddPerson { get; set; }

    public AnketViewModel()
    {
<<<<<<< HEAD
        DbContext = new(FileName);
        NewPerson = new Person();
        SelectedPerson = null;
        AddCommand = new RelayCommand(AddPerson,obj => NewPerson.IsValid());
        SaveCommand = new RelayCommand(SavePeople);
        LoadCommand = new RelayCommand(LoadPeople);

    }



    public void AddPerson(object? param)
    {
        
        DbContext.AddPerson(NewPerson);
        NewPerson = new Person();
=======
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
>>>>>>> c511e1b7491fafea2a5546e4a05376a315ad5ac9
    }

    public void SavePeople(object? param)
    {
        if (FileName is not null) 
        { 
            DbContext.SaveChanges();
            DbContext.People = new ObservableCollection<Person>();
            MessageBox.Show("ADD To People");
        }
        else MessageBox.Show("File Name Not Null");
    }

    public void LoadPeople(object? param)
    {
        if (FileName is not null && File.Exists(FileName))
        {
            var json = File.ReadAllText(FileName);
            DbContext.People = JsonSerializer.Deserialize<ObservableCollection<Person>>(json)!;
        }
        else MessageBox.Show("File Not Found");
    }


    // -----------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    // -----------------------------------------------------------------



    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    
}
