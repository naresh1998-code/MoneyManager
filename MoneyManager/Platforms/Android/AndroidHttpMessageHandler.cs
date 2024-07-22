
using System.Net.Security;
using Xamarin.Android.Net;

namespace MoneyManager;

public class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
{
    public HttpMessageHandler GetHttpMessageHandler() => new AndroidMessageHandler
    {
        ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
        certificate?.Issuer == "cn-localhost" || sslPolicyErrors == SslPolicyErrors.None
    };
}
