namespace FirstMAUI.Views;

public partial class LoginPage : ContentPage
{
    private Boolean isLoginByEmail = false;
    public LoginPage()
    {
        InitializeComponent();
    }

    public void LoginByEmailClicked(object sender, EventArgs e)
    {
        this.isLoginByEmail = true;
        if (isLoginByEmail)
        {
            App.Current!.Windows[0].Page = new AppShell();
        }
    }
}