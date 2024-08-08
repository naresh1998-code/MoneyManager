namespace MoneyManager.Views;

public partial class AccountPage : ContentPage
{
	//AccountViewModel _accountViewModel;
	public AccountPage(AccountViewModel accountViewModel)
	{
		InitializeComponent();
		//_accountViewModel = accountViewModel;
		BindingContext = accountViewModel;
	}
}