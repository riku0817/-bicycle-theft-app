using Maui.GoogleMaps;

namespace BicycleTheftApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            PermissionStatus result = await CheckAndRequestLocationPermission();

            if (result == PermissionStatus.Granted)
            {

                Location location = await Geolocation.Default.GetLocationAsync();

                if (location != null)
                {
                    //現在地取得コード Maui.GoogleMaps.Position myposition = new Maui.GoogleMaps.Position(location.Latitude, location.Longitude);

                    Maui.GoogleMaps.Position myposition = new Maui.GoogleMaps.Position(35.710006892117, 139.81081025188); // 東京スカイツリーの緯度経度を初期位置に設定


                    await mymap.MoveCamera(CameraUpdateFactory.NewCameraPosition(
                               new CameraPosition(
                                  myposition, // Tokyo
                                   17d, // zoom
                                   45d, // bearing(rotation)
                                   0d // tilt
                                   )));
                    Pin _pinA = new Pin()
                    {
                        Icon = BitmapDescriptorFactory.FromBundle("pinmarker"), //don't use extension
                        Type = PinType.Place,
                        Label = "Tokyo SKYTREE",
                        Address = "Sumida-ku, Tokyo, Japan",
                        Position = myposition
                    };
                    mymap.Pins.Add(_pinA);
                }

            }
        }



        async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return status;
        }

    }

}
