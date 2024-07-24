using MoneyManager.Services;

namespace MoneyManager.ViewModels;

public partial class AccountTypesViewModel : BaseViewModel
{
    
    public ObservableCollection<AccountType> _accountTypes { get; } = new();

    AccountTypeServices _accountTypeServices;

    public AccountTypesViewModel(AccountTypeServices accountTypeService)
    {
        _accountTypeServices = accountTypeService;
    }

    [RelayCommand]
    async Task GetAccountTypes()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var accounttypes = await _accountTypeServices.GetAccountTypes();

            if (_accountTypes!.Count > 0)
                _accountTypes.Clear();

            foreach (var item in accounttypes)
            {
                _accountTypes.Add(item);
            }

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            throw;
        }
        finally
        {
            IsBusy = false;
        }

    }


}
