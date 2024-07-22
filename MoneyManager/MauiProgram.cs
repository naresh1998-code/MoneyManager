using Microsoft.Extensions.Logging;
using MoneyManager.Views;

namespace MoneyManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            // Add IPlatformHttpMessageHandler
            builder.Services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
            {
#if ANDROID
                return new AndroidHttpMessageHandler();
#else
                return null!;
#endif
            });

            // Add HttpClient 
            builder.Services.AddHttpClient("custom-httpclient", httpClient =>
            {
                var BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7009" : "https://localhost:7009";
                httpClient.BaseAddress = new Uri(BaseAddress);
            })
            .ConfigurePrimaryHttpMessageHandler(serviceProvider =>
            {
                var platformMessageHandler = serviceProvider.GetRequiredService<IPlatformHttpMessageHandler>();
                return platformMessageHandler.GetHttpMessageHandler();
            });


            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<Login>();
            builder.Services.AddSingleton<TabbedMainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
