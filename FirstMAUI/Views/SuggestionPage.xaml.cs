namespace FirstMAUI.Views;

public partial class SuggestionPage : ContentPage
{
    public SuggestionPage()
    {
        InitializeComponent();
        var scholarships = MockScholarshipSuggestionData.GetAll();
        BindingContext = new { Scholarships = scholarships.OrderByDescending(p => p.SuitableLevel).ToList() };
    }
}