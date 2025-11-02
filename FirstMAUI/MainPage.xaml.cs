using FirstMAUI.Views;

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
            await Navigation.PushAsync(new LoginPage());
        }

        private async void NavigateToScholarshipClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScholarshipListPage());
        }
    }
}
