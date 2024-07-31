using Microsoft.Extensions.Logging;
using MoneyManager.Services;
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
                var BaseAddress = "https://localhost:5106";
                httpClient.BaseAddress = new Uri(BaseAddress);
            });
            //.ConfigurePrimaryHttpMessageHandler(serviceProvider =>
            //{
            //    var platformMessageHandler = serviceProvider.GetRequiredService<IPlatformHttpMessageHandler>();
            //    return platformMessageHandler.GetHttpMessageHandler();
            //});

            

            //Register AccountTypes
            builder.Services.AddSingleton<AccountTypeServices>();
            builder.Services.AddSingleton<AccountTypesViewModel>();
            builder.Services.AddSingleton<AccountTypeList>();

            //Register Account
            builder.Services.AddSingleton<AccountServices>();
            builder.Services.AddSingleton<AccountViewModel>();
            builder.Services.AddSingleton<AccountPage>();


            // Add Pages
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
