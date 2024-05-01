using Anket_WPF_MVVM.Commands;
using Anket_WPF_MVVM.Data;
using Anket_WPF_MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;

namespace Anket_WPF_MVVM.ViewModels;

public class AnketViewModel
{
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


    public AnketViewModel()
    {
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



}
