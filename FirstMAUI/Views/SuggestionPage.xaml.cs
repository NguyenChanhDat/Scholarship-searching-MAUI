using FirstMAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FirstMAUI.Views;

public partial class SuggestionPage : ContentPage
{

    public ObservableCollection<ScholarshipSuggestion> Scholarships { get; set; }

    public ICommand NavigateToDetailCommand { get; }

    public SuggestionPage()
    {
        InitializeComponent();
        Scholarships = new ObservableCollection<ScholarshipSuggestion>(
            MockScholarshipSuggestionData.GetAll()
                .OrderByDescending(p => p.SuitableLevel)
                );

        NavigateToDetailCommand = new Command<ScholarshipSuggestion>(OnNavigateToDetail);
        BindingContext = this;
    }

    private async void OnNavigateToDetail(ScholarshipSuggestion selectedScholarship)
    {
        if (selectedScholarship == null)
            return;

        var scholarship = MockScholarshipData.GetAll().FirstOrDefault(s => s.Id == selectedScholarship.Id);

        var navParameter = new Dictionary<string, object>
        {
            { "Scholarship", scholarship }
        };

        await Shell.Current.GoToAsync(nameof(ScholarshipDetailPage), navParameter);
    }
}