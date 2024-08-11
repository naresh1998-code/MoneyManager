namespace MoneyManager.Views;


public partial class HomePage : ContentPage
{
	public HomePage(AccountViewModel accountViewModel)
	{
		InitializeComponent();
        BindingContext = accountViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
    }
}