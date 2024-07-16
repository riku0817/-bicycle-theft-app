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

                    Maui.GoogleMaps.Position myposition = new Maui.GoogleMaps.Position(37.401390, 140.365076); // カメラ初期位置を福島県に


                    await mymap.MoveCamera(CameraUpdateFactory.NewCameraPosition(
                               new CameraPosition(
                                  myposition, // Tokyo
                                   17d, // zoom
                                   45d, // bearing(rotation)
                                   0d // tilt
                                   )));

                    System.IO.StringReader positiontxt = new System.IO.StringReader(Properties.Resources.position);
                    System.IO.StringReader theftinfotxt = new System.IO.StringReader(Properties.Resources.theftinfo);
                    System.IO.StringReader locationinfotxt = new System.IO.StringReader(Properties.Resources.locationinfo);
                    // ↑ この行でResourceフォルダに入ってるtxtファイルを読み込んでる

                    while (positiontxt.Peek() > -1)
                    {
                        //一行読み込んで表示する
                        string[] xy = positiontxt.ReadLine().Split(',');
                        string info = theftinfotxt.ReadLine();
                        int records = int.Parse(info);

                        if (records <= 5)
                        {
                            Pin _pinA = new Pin()
                            {
                                Icon = BitmapDescriptorFactory.FromBundle("skiiro"), //don't use extension
                                Type = PinType.Place,
                                Label = $"場所：{locationinfotxt.ReadLine()}",
                                Address = $"盗難被害{info}件",
                                Position = new Position(double.Parse(xy[0]), double.Parse(xy[1].Replace(" ", "")))
                            };
                            mymap.Pins.Add(_pinA);
                        }
                        else if (records <= 10)
                        {
                            Pin _pinB = new Pin()
                            {
                                Icon = BitmapDescriptorFactory.FromBundle("sorenzi"), //don't use extension
                                Type = PinType.Place,
                                Label = $"場所：{locationinfotxt.ReadLine()}",
                                Address = $"盗難被害{info}件",
                                Position = new Position(double.Parse(xy[0]), double.Parse(xy[1].Replace(" ", "")))
                            };
                            mymap.Pins.Add(_pinB);
                        }
                        else if (records <= 15)
                        {

                            Pin _pinC = new Pin()
                            {
                                Icon = BitmapDescriptorFactory.FromBundle("taka"), //don't use extension
                                Type = PinType.Place,
                                Label = $"場所：{locationinfotxt.ReadLine()}",
                                Address = $"盗難被害{info}件",
                                Position = new Position(double.Parse(xy[0]), double.Parse(xy[1].Replace(" ", "")))
                            };
                            mymap.Pins.Add(_pinC);
                        }

                        else
                        {
                            Pin _pinD = new Pin()
                            {
                                Icon = BitmapDescriptorFactory.FromBundle("smurasaki"), //don't use extension
                                Type = PinType.Place,
                                Label = $"場所：{locationinfotxt.ReadLine()}",
                                Address = $"盗難被害{info}件",
                                Position = new Position(double.Parse(xy[0]), double.Parse(xy[1].Replace(" ", "")))
                            };
                            mymap.Pins.Add(_pinD);
                        }
                    }
                        positiontxt.Close();
                    theftinfotxt.Close();
                    locationinfotxt.Close();
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
