namespace MoneyManager.Services;

internal interface ILoginRepository
{
    Task<LoginResponseModel> Login(string email, string password);
}
