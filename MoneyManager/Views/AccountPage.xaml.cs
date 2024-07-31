namespace MoneyManager.Views;

public partial class AccountPage : ContentPage
{
	AccountViewModel _accountViewModel;
	public AccountPage(AccountViewModel accountViewModel)
	{
		InitializeComponent();
		_accountViewModel = accountViewModel;
		BindingContext = _accountViewModel;
	}

    private async void accountCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		_accountViewModel.selectedAccount = (Account)e.CurrentSelection[0];

		accountBalanceEntry.Text = _accountViewModel.selectedAccount.balance.ToString();
		accountBankNameEntry.Text = _accountViewModel.selectedAccount.bankName;
		accountNameEntry.Text = _accountViewModel.selectedAccount.accountName;
		accountTypeEntry.Text = _accountViewModel.selectedAccount.accountType;
		accountRemarkEntry.Text = _accountViewModel.selectedAccount.remark;
        await Shell.Current.DisplayAlert("Message", ((Account)e.CurrentSelection[0]).accountName, "Ok");
    }
}