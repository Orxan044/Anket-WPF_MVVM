using Anket_WPF_MVVM.ViewModels;
using System.Windows;

namespace Anket_WPF_MVVM.Views;

public partial class Anket : Window
{
    public Anket()
    {
        InitializeComponent();
        DataContext = new AnketViewModel();
    }
}
