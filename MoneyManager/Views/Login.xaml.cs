using MoneyManager.Models;

namespace MoneyManager.Views;

public partial class Login : ContentPage
{
	public Login(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}


}