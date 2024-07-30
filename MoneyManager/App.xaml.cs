namespace MoneyManager
{
    public partial class App : Application
    {
        public static LoginResponseModel user;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
