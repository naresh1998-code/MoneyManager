using System.Net.Http.Json;

namespace MoneyManager.Services;

public class AccountServices
{
    List<Account> _accountList = []; // for GetAccounts
    readonly HttpClient _httpClient;
    private const string baseurl = "https://localhost:5106";
    public AccountServices()
    {
        _httpClient = new();
        _httpClient.BaseAddress = new Uri(baseurl);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.user.AccessToken);

    }

   

    public async Task<List<Account>> GetAccounts()
    {
        //if (_accountList.Count > 0)
        //    return _accountList;
       


            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Account>>("/MoneyManager/GetAccount");
                if (response != null)
                    _accountList = response;
            }
            catch (Exception)
            {
                throw;
            }

        return _accountList;
    }


    public async Task AddAccount(Account account)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync<Account>("/MoneyManager/AddAccount", account);
            if (response.IsSuccessStatusCode)
                await Shell.Current.DisplayAlert("Response", "Account Added", "Ok");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateAccount(Account account)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync<Account>("/MoneyManager/UpdateAccount", account);
            if (response.IsSuccessStatusCode)
                await Shell.Current.DisplayAlert("Response", "Account Updated", "Ok");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAccount(int accountId)
    {
        try
        {
            var response = await _httpClient.PostAsync($"/MoneyManager/DeleteAccount?accountID={accountId}", null);
            if (response.IsSuccessStatusCode)
                await Shell.Current.DisplayAlert("Response", "Account Removed", "Ok");
        }
        catch (Exception)
        {

            throw;
        }
    }
}
