using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Locations;

namespace Demo1.Droid
{
	[Activity(Label = "Demo1.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		const int RequestLocationId = 0;

		protected async override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

			await TryGetLocationAsync();
		}

		async Task TryGetLocationAsync()
		{
			if ((int)Build.VERSION.SdkInt < 23)
			{
				await GetLocationAsync();
				return;
			}

			await GetLocationPermissionAsync();
		}

		async Task GetLocationPermissionAsync()
		{
			string[] PermissionsLocation =
			{
			  Manifest.Permission.AccessCoarseLocation,
			  Manifest.Permission.AccessFineLocation
			};

			if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == (int)Permission.Granted)
			{
				await GetLocationAsync();
				return;
			}
			ActivityCompat.RequestPermissions(this, PermissionsLocation, RequestLocationId);
		}

		async Task GetLocationAsync()
		{
			LocationManager locMgr;
			locMgr = GetSystemService(Context.LocationService) as LocationManager;
		}

		public async override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			switch (requestCode)
			{
				case RequestLocationId:
					{
						if (grantResults[0] == Permission.Granted)
						{
							//Permission granted
							await GetLocationAsync();
						}
						else
						{
							//Permission Denied :(
						}
					}
					break;
			}
		}
	}
}
