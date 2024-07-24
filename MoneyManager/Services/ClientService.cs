//using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MoneyManager.Services;

public class ClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task Register(RegisterModel registerModel)
    {
        var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsJsonAsync("/register", registerModel);
        if (result.IsSuccessStatusCode)
        {
            await Shell.Current.DisplayAlert("Alert", "Sucessfully Registered", "Ok");
        }
        await Shell.Current.DisplayAlert("Alert", result.ReasonPhrase, "Ok");
    }

    public async Task Login(LoginModel loginModel)
    {
        var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsJsonAsync("/login", loginModel);
        LoginResponseModel? response = await result.Content.ReadFromJsonAsync<LoginResponseModel>();
        if (response is not null)
        {
            var seralisedResponse = JsonSerializer.Serialize(
                    new LoginResponseModel() 
                    { 
                        AccessToken= response.AccessToken,
                        RefreshToken= response.RefreshToken,
                        Username = response.Username
                    });
            await SecureStorage.Default.SetAsync("Authentication", seralisedResponse);
        }
    }


    public async Task<WeatherForecast[]>? GetAccounts()
    {
        var seralisedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
        if (seralisedLoginResponseInStorage is null) return null;

        string token = JsonSerializer.Deserialize<LoginResponseModel>(seralisedLoginResponseInStorage)!.AccessToken;
        var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("/Accounts");
        return result!;
    }
}
