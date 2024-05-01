using Anket_WPF_MVVM.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Anket_WPF_MVVM.Data;

public class AppDbContext
{

    public ObservableCollection<Person> People { get; set; }
    private string? _filename;

    public AppDbContext(string? FileName)
    {
        _filename = $"{FileName}.json";
        if (File.Exists(_filename))
        {
            var json = File.ReadAllText(_filename);
            People = JsonSerializer.Deserialize<ObservableCollection<Person>>(json)!;
        }
        else People = new();
    }


    public void AddPerson(Person person) => People.Add(person);
    public void RemovePerson(Person person) => People.Add(person);

    public void UptadePerson(Person person) 
    {
    }

    public void SaveChanges()
    {
        var json = JsonSerializer.Serialize(People);
        File.WriteAllText(_filename!, json);
    }
}