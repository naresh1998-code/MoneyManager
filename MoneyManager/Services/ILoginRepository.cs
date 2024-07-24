namespace MoneyManager.Services;

internal interface ILoginRepository
{
    Task<User> Login(string email, string password);
}
