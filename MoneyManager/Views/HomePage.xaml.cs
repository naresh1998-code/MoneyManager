namespace MoneyManager.Views;


public partial class HomePage : ContentPage
{
	public HomePage(AccountTypesViewModel accountTypeViewModel)
	{
		InitializeComponent();
        BindingContext = accountTypeViewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AccountPage));
    }
}