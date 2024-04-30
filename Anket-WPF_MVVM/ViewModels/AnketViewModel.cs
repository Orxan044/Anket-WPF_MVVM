using Anket_WPF_MVVM.Commands;
using Anket_WPF_MVVM.Models;
using System.Collections.ObjectModel;

namespace Anket_WPF_MVVM.ViewModels;

public class AnketViewModel
{
    public ObservableCollection<Person> Persons { get; set; }
    private Person Person { get; set; } 

    public RelayCommand AddPerson { get; set; }


    public AnketViewModel()
    {
        Persons = new();
    }

    private void Add(object? parameter)
    {
        //Person = new()
        //{
        //    Name = Person.Name,
        //};
    }


}
