﻿namespace MoneyManager.Models;

public class LoginResponseModel
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string Username { get; set; }
}
