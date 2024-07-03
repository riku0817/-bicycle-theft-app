using Microsoft.Extensions.Logging;
using Maui.GoogleMaps.Hosting;

namespace BicycleTheftApp
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
#if ANDROID
        builder.UseGoogleMaps();
#elif IOS
        builder.UseGoogleMaps("AIzaSyBJ49vDzRYDiNo7wvmPNa7Bo6PVcurCd9w");
#endif

            return builder.Build();
        }
    }
}
