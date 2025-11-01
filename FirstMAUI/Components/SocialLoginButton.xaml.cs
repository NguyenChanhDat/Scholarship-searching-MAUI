namespace FirstMAUI.Components;

public partial class SocialLoginButton : ContentView
{

    private Boolean isLoginWithGoogle = false;
    //private Boolean isLoginWithFacebook = false;
    public SocialLoginButton()
    {
        InitializeComponent();
    }

    public async void OnGoogleLoginClicked(object sender, EventArgs e)
    {
        this.isLoginWithGoogle = true;
        if (this.isLoginWithGoogle)
        {
            await AppShell.Current.GoToAsync(nameof(ScholarshipListPage));
        }
    }

    public void OnGoogleFacebookClicked(object sender, EventArgs e)
    {

    }
}