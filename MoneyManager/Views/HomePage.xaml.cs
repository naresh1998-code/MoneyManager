namespace MoneyManager.Views;


public partial class HomePage : ContentPage
{
	public HomePage(AccountTypesViewModel accountTypeViewModel)
	{
		InitializeComponent();
        BindingContext = accountTypeViewModel;
    }
}