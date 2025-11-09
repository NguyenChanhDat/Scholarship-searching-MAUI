using FirstMAUI.Models;

namespace FirstMAUI.Views;

[QueryProperty(nameof(Scholarship), "Scholarship")]
public partial class ScholarshipDetailPage : ContentPage
{
    private Scholarship _scholarship;
    public Scholarship Scholarship
    {
        get => _scholarship;
        set
        {
            _scholarship = value;
            OnPropertyChanged();
            // pass data to ContentView
            DetailView.Scholarship = value;
        }
    }

    public ScholarshipDetailPage()
    {
        InitializeComponent();
    }
}
