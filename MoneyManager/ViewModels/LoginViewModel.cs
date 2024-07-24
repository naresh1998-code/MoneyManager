using MoneyManager.Services;
using MoneyManager.Views;
using Newtonsoft.Json;

namespace MoneyManager.Models;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _email = null!;
    [ObservableProperty]
    private string _password = null!;

    readonly ILoginRepository loginService = new LoginServices();

    [RelayCommand]
    public async void SignIn()
    {
        // To check if internet connection is available
        //if(Connectivity.Current.NetworkAccess == NetworkAccess.Internet) { }

        try
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                User user = await loginService.Login(Email, Password);
                if (Preferences.ContainsKey(nameof(App.user)))
                {
                    Preferences.Remove(nameof(App.user));
                }
                string userDetails = JsonConvert.SerializeObject(user);
                Preferences.Set(nameof(App.user), userDetails);
                App.user = user;
                await Shell.Current.GoToAsync(nameof(HomePage));
            }

        }
        catch (Exception Ex)
        {
            await Shell.Current.DisplayAlert("Error", Ex.Message, "OK");
            return;
        }

    }
}
