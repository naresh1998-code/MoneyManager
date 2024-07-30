namespace MoneyManager.Views;

public partial class Account : ContentPage
{
	public Account(AccountViewModel accountViewModel)
	{
		InitializeComponent();
		BindingContext = accountViewModel;
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}