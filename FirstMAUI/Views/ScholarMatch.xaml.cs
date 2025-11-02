namespace FirstMAUI.Views;

public partial class ScholarMatch : ContentPage
{
    public ScholarMatch()
    {
        InitializeComponent();
        BindingContext = new { Scholarships = MockScholarshipData.GetAll() };
    }
}