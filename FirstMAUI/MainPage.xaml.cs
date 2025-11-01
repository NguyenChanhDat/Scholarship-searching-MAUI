namespace FirstMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavigateToLoginClicked(object sender, EventArgs e)
        {
            await AppShell.Current.GoToAsync(nameof(LoginPage));
        }

        private async void NavigateToScholarshipClicked(object sender, EventArgs e)
        {
            await AppShell.Current.GoToAsync(nameof(ScholarshipListPage));
        }
    }
}
