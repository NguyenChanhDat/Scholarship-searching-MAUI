using FirstMAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FirstMAUI.Views;

public partial class ScholarMatch : ContentPage
{
    public ObservableCollection<Scholarship> Scholarships { get; set; }

    public ICommand NavigateToDetailCommand { get; }

    public ScholarMatch()
    {
        InitializeComponent();
        Scholarships = new ObservableCollection<Scholarship>(MockScholarshipData.GetAll());
        NavigateToDetailCommand = new Command<Scholarship>(OnNavigateToDetail);
        BindingContext = this;
    }

    private async void OnNavigateToDetail(Scholarship selectedScholarship)
    {
        if (selectedScholarship == null)
            return;

        var navParameter = new Dictionary<string, object>
        {
            { "Scholarship", selectedScholarship }
        };

        await Shell.Current.GoToAsync(nameof(ScholarshipDetailPage), navParameter);
        //await Navigation.PushAsync(new ScholarshipDetail(selected.Id));

    }

}