using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyManager.Models;
using MoneyManager.Services;
using MoneyManager.Views;
using System.Text.Json;

namespace MoneyManager.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private LoginModel loginModel;

    [ObservableProperty]
    private RegisterModel registerModel;

    [ObservableProperty]
    public string userName;
    [ObservableProperty]
    public bool isAuthenticated;

    private readonly ClientService clientService;

    public  MainPageViewModel(ClientService clientService)
    {
        this.clientService = clientService;
        registerModel = new();
        loginModel = new();
        isAuthenticated = false;
        GetUserNameFromSecureStorage();
    }

    [RelayCommand]
    private async Task Register()
    {
        await clientService.Register(RegisterModel);
    }

    [RelayCommand]
    private async Task Login()
    {
        await clientService.Login(LoginModel);
        GetUserNameFromSecureStorage();
    }

    private async void GetUserNameFromSecureStorage()
    {
        if(!string.IsNullOrEmpty(UserName) && UserName! != "Guest")
        {
            IsAuthenticated = true;
            return;
        }
        var seralisedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
        if (seralisedLoginResponseInStorage != null)
        {
            UserName = JsonSerializer.Deserialize<LoginResponseModel>(seralisedLoginResponseInStorage)!.Username;
            isAuthenticated = true;
            return;
        }
        UserName = "Guest";
    }

    private async Task GoToWeatherForecast()
    {
        await Shell.Current.GoToAsync(nameof(TabbedMainPage));
    }



}
