using System.Net.Http.Json;

namespace MoneyManager.Services;

public class AccountServices
{
    List<Account> _accountList = []; // for GetAccounts
    readonly HttpClient _httpClient;
    private const string baseurl = "https://localhost:5106";
    const string token = "CfDJ8JV1HvYVzyVIiZXZe4jvqbuAeznVNNgeBb1MHxeWu-6jDa_GT16UOZZLoM5JNjlR_YxsLsn4-UDz6_l3FaypbIBI17DKVvxQcBHunpCpmnIhQcsvEEAuH5MDTkNIJQdbG6De3ohRPWIzJ9hObVqqx9uPIKEPsMNe7q7mx2xjX4-gRUN-dd5jV2nZ_hD4XynD72Ry3vGHmm_s4VIcEecN5WRjIyvwTEPIfhq4ZIC3kA6qsuryO66mFsNeFeKxDhp1pJsfCurO1rS-3nD7OyMOeWvTHn5bRcPIHFHofeAGkd9GZWsUeiKp4u4uDogcMR5ev55JmLOsgsJ-8Hoe-9jFtLA8rLn0HTzs5Jogq2zcqzmWjAWok1NHOSvj8ZKOWdp72SN3kF03XfS7C929hF-TUBgQokJ2DRqJeLWkTVysqZ2-1W0xeE4I819PU7PX7lvUBoXXfoSxjSTyBezEdK9PbbdbL3bl1R0qG4jxbn0rxwahMjkFEgtqIQBufQDgyiHMJy1zgL4H9Nl1Un6TfYbgO3eHMCBuLMKBbHQZSpWkjMHYkAOxcQt4Pqkdu7ZXJTg0UzuZE_vCr_QcFlol03bfG5IXZJ0qGT2rXinwQql5_gv_o3QJNVufhLmt6low8XkuW5CDw2YHbh-QIBNSXT8RiobtsOTGMyAqL6_L_1chJge0BIscUe81F97lCP7q9tVmpw";
    public AccountServices()
    {
        _httpClient = new();
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token); 
        _httpClient.BaseAddress = new Uri(baseurl);
        
    }

    public async Task<List<Account>> GetAccounts()
    {
        if (_accountList.Count > 0)
            return _accountList;

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
