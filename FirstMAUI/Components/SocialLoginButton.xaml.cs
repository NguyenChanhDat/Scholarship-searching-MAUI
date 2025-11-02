namespace FirstMAUI.Components;

public partial class SocialLoginButton : ContentView
{

    private Boolean isLoginWithGoogle = false;
    private Boolean isLoginWithFacebook = false;
    public SocialLoginButton()
    {
        InitializeComponent();
    }

    public void OnGoogleLoginClicked(object sender, EventArgs e)
    {
        this.isLoginWithGoogle = true;
        if (this.isLoginWithGoogle)
        {
            App.Current!.Windows[0].Page = new AppShell();
        }
    }

    public void OnGoogleFacebookClicked(object sender, EventArgs e)
    {
        this.isLoginWithFacebook = true;
        if (this.isLoginWithFacebook)
        {
            App.Current!.Windows[0].Page = new AppShell();
        }
    }
}