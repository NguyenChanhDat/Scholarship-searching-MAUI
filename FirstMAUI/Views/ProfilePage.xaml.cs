using FirstMAUI.Mocks;

namespace FirstMAUI.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();

        // load a mock user for demo
        var mockUser = MockUserPersonalInfor.GetAll().FirstOrDefault(u => u.Id == 1);
        if (mockUser != null)
        {
            UserView.User = mockUser;
        }
    }
}
