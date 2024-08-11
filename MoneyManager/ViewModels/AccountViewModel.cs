namespace MoneyManager.ViewModels;

public partial class AccountViewModel : BaseViewModel
{
    // variable declerations
    public ObservableCollection<Account> _accountList { get; } = new()
    {
        new Account()
        {
            accountId = 1,
            accountName = "Main Account",
            accountType = "current",
            balance = 52000.10M,
            bankName = "SBI",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 2,
            accountName = "Home",
            accountType = "saving",
            balance = 12000.10M,
            bankName = "Canara",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 3,
            accountName = "Offer",
            accountType = "saving",
            balance = 100.10M,
            bankName = "SBI",
            remark = "red_down_right_arrow.png"
        },new Account()
        {
            accountId = 1,
            accountName = "Main Account",
            accountType = "current",
            balance = 52000.10M,
            bankName = "SBI",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 2,
            accountName = "Home",
            accountType = "saving",
            balance = 12000.10M,
            bankName = "Canara",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 3,
            accountName = "Offer",
            accountType = "saving",
            balance = 100.10M,
            bankName = "SBI",
            remark = "red_down_right_arrow.png"
        },new Account()
        {
            accountId = 1,
            accountName = "Main Account",
            accountType = "current",
            balance = 52000.10M,
            bankName = "SBI",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 2,
            accountName = "Home",
            accountType = "saving",
            balance = 12000.10M,
            bankName = "Canara",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 3,
            accountName = "Offer",
            accountType = "saving",
            balance = 100.10M,
            bankName = "SBI",
            remark = "red_down_right_arrow.png"
        },new Account()
        {
            accountId = 1,
            accountName = "Main Account",
            accountType = "current",
            balance = 52000.10M,
            bankName = "SBI",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 2,
            accountName = "Home",
            accountType = "saving",
            balance = 12000.10M,
            bankName = "Canara",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 3,
            accountName = "Offer",
            accountType = "saving",
            balance = 100.10M,
            bankName = "SBI",
            remark = "red_down_right_arrow.png"
        },new Account()
        {
            accountId = 1,
            accountName = "Main Account",
            accountType = "current",
            balance = 52000.10M,
            bankName = "SBI",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 2,
            accountName = "Home",
            accountType = "saving",
            balance = 12000.10M,
            bankName = "Canara",
            remark = "green_up_right_arrow.png"
        },
        new Account()
        {
            accountId = 3,
            accountName = "Offer",
            accountType = "saving",
            balance = 100.10M,
            bankName = "SBI",
            remark = "red_down_right_arrow.png"
        }
    }; // observable list for GetAccounts

    AccountServices _accountServices;

    [ObservableProperty]
    public Account selectedAccount = null!; // for storing selected account

    public AccountViewModel(AccountServices accountServices)
    {
        _accountServices = accountServices;
        SelectedAccount = new Account();
    }


    // commands for conversation with API
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
    async Task UpdateAccount(Account account)
    {
        await _accountServices.UpdateAccount(account);
    }

    [RelayCommand]
    async Task DeleteAccount(int accountId)
    {
        await _accountServices.DeleteAccount(accountId);
    }

    // commands for internal operation

}
