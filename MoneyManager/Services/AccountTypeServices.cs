using MoneyManager.Models;
using System.Net.Http.Json;

namespace MoneyManager.Services;

public class AccountTypeServices
{
    List<AccountType> _accountTypes = [];
    readonly HttpClient _httpClient;
    public AccountTypeServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }



    public async Task<List<AccountType>> GetAccountTypes()
    {
        if (_accountTypes?.Count > 0)
            return _accountTypes;
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<AccountType>>("https://localhost:5106/MoneyManager/GetAccountTypes");
            _accountTypes = response!;

        }
        catch (Exception)
        {
            throw;
        }


        return _accountTypes;
    }
}
