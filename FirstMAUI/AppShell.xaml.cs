using FirstMAUI.Views;
namespace FirstMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ScholarshipListPage), typeof(ScholarshipListPage));
            Routing.RegisterRoute(nameof(ScholarMatch), typeof(ScholarMatch));
            Routing.RegisterRoute(nameof(ScholarshipDetail), typeof(ScholarshipDetail));
        }
    }
}
