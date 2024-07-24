using System.Net.Http.Json;

namespace MoneyManager.Services;

internal class LoginServices : ILoginRepository
{
    public async Task<User> Login(string email, string password)
    {
        try
        {
            var client = new HttpClient();
            string url = $"https://localhost:5505/api/Login/{email}/{password}";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                User? user = await response.Content.ReadFromJsonAsync<User>();
                return await Task.FromResult(user!);
            }
            return null!;

        }catch (Exception Ex)
        {
            await Shell.Current.DisplayAlert("Error", Ex.Message, "OK");
            return null!;
        }
    }
}
