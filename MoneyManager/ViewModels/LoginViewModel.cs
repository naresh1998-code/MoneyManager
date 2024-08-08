using MoneyManager.Services;
using MoneyManager.Views;
using Newtonsoft.Json;

namespace MoneyManager.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _email = null!;
    [ObservableProperty]
    private string _password = null!;

    readonly LoginServices loginService = new LoginServices();

    [RelayCommand]
    public async Task SignIn()
    {
        // To check if internet connection is available
        //if(Connectivity.Current.NetworkAccess == NetworkAccess.Internet) { }
            if (IsBusy)
                return;

        try
        {
            IsBusy = true;

            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                var user = await loginService.Login(Email, Password);
                if (user != null)
                {
                    if (Preferences.ContainsKey(nameof(App.user)))
                    {
                        Preferences.Remove(nameof(App.user));
                    }
                    string userDetails = JsonConvert.SerializeObject(user);
                    Preferences.Set(nameof(App.user), userDetails);
                    App.user = user;
                    await Shell.Current.GoToAsync(nameof(HomePage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Invalid Login Details" , "Ok");
                }
            }

        }
        catch (Exception Ex)
        {
            await Shell.Current.DisplayAlert("Error", Ex.Message, "OK");
            return;
        }
        finally
        {
            IsBusy = false;
        }

    }
}
