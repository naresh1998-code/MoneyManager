
using MoneyManager.Services;

namespace MoneyManager.ViewModels;

public partial class AccountViewModel : BaseViewModel
{
    public ObservableCollection<Account> _accountList { get; } = new(); // observable list for GetAccounts

    AccountServices _accountServices;

    public AccountViewModel(AccountServices accountServices)
    {
        _accountServices = accountServices;
    }

    [RelayCommand]
    async Task GetAccounts()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var accountGetList = await _accountServices.GetAccounts();

            if (_accountList.Count > 0)
                _accountList.Clear();

            foreach (var account in accountGetList)
                _accountList.Add(account);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            throw;
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task AddAccount(Account account)
    {
        await _accountServices.AddAccount(account);
    }

    [RelayCommand]
    async Task UpdateAccount(AccountUpdate accountUpdate)
    {
        await _accountServices.UpdateAccount(accountUpdate);
    }

    [RelayCommand]
    async Task DeleteAccount(int accountId)
    {
        await _accountServices.DeleteAccount(accountId);
    }
}
