using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Microblink.Forms.Droid;

namespace BlinkIDApp
{
	[Activity (Label = "BlinkIDFormsSample.Droid", Icon = "@drawable/icon", HardwareAccelerated = true, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, global::Microblink.Forms.Droid.IMicroblinkScannerAndroidHostActivity
	{
        public MicroblinkScannerImplementation currentScannerImplementation;

        public Activity HostActivity => this;

        public int ScanActivityRequestCode => 101;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            MicroblinkScannerFactoryImplementation.AndroidHostActivity = this;

			// Set our view from the "main" layout resource
			RequestedOrientation = ScreenOrientation.Portrait;

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            currentScannerImplementation.OnActivityResult(requestCode, resultCode, data);
        }

        public void ScanningStarted(MicroblinkScannerImplementation implementation)
        {
            this.currentScannerImplementation = implementation;
        }
    }
}

