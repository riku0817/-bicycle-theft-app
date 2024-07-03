using Android.App;
using Android.Runtime;

namespace BicycleTheftApp
{
    [Application]
    [MetaData("com.google.android.maps.v2.API_KEY",
            Value = "AIzaSyBJ49vDzRYDiNo7wvmPNa7Bo6PVcurCd9w")]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {

        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
