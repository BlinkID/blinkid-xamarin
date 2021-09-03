using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using BlinkID.Forms.Droid;

namespace BlinkIDApp
{
	[Activity (Label = "BlinkIDFormsSample.Droid", Icon = "@drawable/icon", HardwareAccelerated = true, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, global::BlinkID.Forms.Droid.IMicroblinkScannerAndroidHostActivity, BlinkCard.Forms.Droid.IMicroblinkScannerAndroidHostActivity
	{
        public MicroblinkScannerImplementation currentScannerImplementation;
        public BlinkCard.Forms.Droid.MicroblinkScannerImplementation currentBlinkCardImplementation;

        /// <summary>
        /// Returns the host activity that is currently in use.
        /// This property is part of IMicroblinkScannerAndroidHostActivity interface.
        /// </summary>
        /// <value>The host activity.</value>
        public Activity HostActivity => this;

        int BlinkID.Forms.Droid.IMicroblinkScannerAndroidHostActivity.ScanActivityRequestCode => 100;
        int BlinkCard.Forms.Droid.IMicroblinkScannerAndroidHostActivity.ScanActivityRequestCode => 101;
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // it is important to register an implementation of IMicroblinkScannerAndroidHostActivity into
            // global property MicroblinkScannerFactoryImplementation.AndroidHostActivity.
            // Without this, android implementation will not be able to start scanning activity.
            MicroblinkScannerFactoryImplementation.AndroidHostActivity = this;
            BlinkCard.Forms.Droid.MicroblinkScannerFactoryImplementation.AndroidHostActivity = this;

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
            if(requestCode == 100)
            {
                currentScannerImplementation.OnActivityResult(requestCode, resultCode, data);
            }else if(requestCode == 101)
            {
                currentBlinkCardImplementation.OnActivityResult(requestCode, resultCode, data);
            }
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

        public void ScanningStarted(BlinkCard.Forms.Droid.MicroblinkScannerImplementation implementation)
        {
            currentBlinkCardImplementation = implementation;
        }
    }
}