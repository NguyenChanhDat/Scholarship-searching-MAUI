namespace FirstMAUI.Views;

public partial class LoginPage : ContentPage
{
    private Boolean isLoginByEmail = false;
    public LoginPage()
    {
        InitializeComponent();
    }

    public async void LoginByEmailClicked(object sender, EventArgs e)
    {
        this.isLoginByEmail = true;
        if (isLoginByEmail)
        {
            await AppShell.Current.GoToAsync(nameof(ScholarshipListPage));
        }
    }
}