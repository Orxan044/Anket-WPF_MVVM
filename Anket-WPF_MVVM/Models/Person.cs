using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Anket_WPF_MVVM.Models;

public class Person : INotifyPropertyChanged
{
<<<<<<< HEAD
    private string? name;
    private string? surname;
    private string? email;
    private string? phoneNumber;
    private DateTime? brithday = DateTime.Now;

    public string? Name { get => name; set { name = value; OnPropertyChanged(); } }
    public string? Surname { get => surname; set { surname = value; OnPropertyChanged(); } }
    public string? Email { get => email; set { email = value; OnPropertyChanged(); } }
    public string? PhoneNumber { get => phoneNumber; set { phoneNumber = value; OnPropertyChanged(); } }
    public DateTime? Brithday { get => brithday; set { brithday = value; OnPropertyChanged(); } }

    public bool IsValid() => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname) 
        && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(PhoneNumber);

    // -----------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null) => 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName)); 
    // -----------------------------------------------------------------
=======
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime Brithday { get; set; }
>>>>>>> c511e1b7491fafea2a5546e4a05376a315ad5ac9

}
