using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using BlinkIDApp.Droid;

namespace BlinkIDApp
{
	[Activity (Label = "BlinkIDFormsSample.Droid", Icon = "@drawable/icon", HardwareAccelerated = true, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
        public static MainActivity Instance { get; set; }
        public BlinkIDImplementation BlinkIDImplementation { get; set; }

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            Instance = this;

			// Set our view from the "main" layout resource
			RequestedOrientation = ScreenOrientation.Portrait;

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Instance = null;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            BlinkIDImplementation.OnActivityResult(requestCode, resultCode, data);
        }
    }
}

