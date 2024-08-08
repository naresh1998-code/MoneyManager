using MoneyManager.Views;

namespace MoneyManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(TabbedMainPage), typeof(TabbedMainPage));
            //Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
            //Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

        }

    }
}
