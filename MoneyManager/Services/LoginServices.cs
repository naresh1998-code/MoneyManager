using System.Net.Http;
using System.Net.Http.Json;

namespace MoneyManager.Services;

internal class LoginServices : ILoginRepository
{
    public async Task<LoginResponseModel?> Login(string email, string password)
    {
        try
        {
            var client = new HttpClient();
            string url = "https://localhost:5106/login";
            client.BaseAddress = new Uri(url);

            LoginModel loginModel = new()
            {
                Email = email,
                Password = password
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress,loginModel);

            if (response.IsSuccessStatusCode)
            {
                LoginResponseModel? user = await response.Content.ReadFromJsonAsync<LoginResponseModel>();
                return user;
            }
            return null!;

        }catch (Exception Ex)
        {
            await Shell.Current.DisplayAlert("Error", Ex.Message, "OK");
            return null!;
        }
    }
}
