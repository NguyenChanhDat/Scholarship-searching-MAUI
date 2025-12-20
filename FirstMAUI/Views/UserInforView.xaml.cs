using FirstMAUI.Models;

namespace FirstMAUI.Views;

public partial class UserInforView : ContentView
{
    private PersonalUserInfor _user;
    public PersonalUserInfor User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged();
            BindingContext = _user;
        }
    }

    public UserInforView()
    {
        InitializeComponent();
    }
}
