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

        /// <summary>
        /// Returns the host activity that is currently in use.
        /// This property is part of IMicroblinkScannerAndroidHostActivity interface.
        /// </summary>
        /// <value>The host activity.</value>
        public Activity HostActivity => this;

        /// <summary>
        /// Gets the scan activity request code. You can define your custom request code
        /// so that it will not interfere with request codes your app uses with other
        /// activities.
        /// </summary>
        /// <value>The scan activity request code.</value>
        public int ScanActivityRequestCode => 101;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // it is important to register an implementation of IMicroblinkScannerAndroidHostActivity into
            // global property MicroblinkScannerFactoryImplementation.AndroidHostActivity.
            // Without this, android implementation will not be able to start scanning activity.
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

        /// <summary>
        /// You must override activity's OnActivityResult method and forward its parameters
        /// to currently saved MicroblinkScannerImplementation.
        /// </summary>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            currentScannerImplementation.OnActivityResult(requestCode, resultCode, data);
        }

        /// <summary>
        /// This method is called from Android's version of MicroblinkScannerImplementation at
        /// the time when scanning will be started. You should save the implementation's object
        /// reference here and use it in OnActivityResult method to forward that event to it.
        /// </summary>
        /// <param name="implementation">Implementation.</param>
        public void ScanningStarted(MicroblinkScannerImplementation implementation)
        {
            currentScannerImplementation = implementation;
        }
    }
}

