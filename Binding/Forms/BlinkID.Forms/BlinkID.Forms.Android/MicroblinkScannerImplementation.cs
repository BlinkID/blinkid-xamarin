using Microblink.Forms.Droid;
using Xamarin.Forms;
using Microblink.Forms.Core;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Com.Microblink;
using Com.Microblink.Uisettings;
using Microblink.Forms.Droid.Overlays;
using Com.Microblink.Entities.Recognizers;
using Android.App;
using Android.Content;
using Microblink.Forms.Droid.Recognizers;
using Com.Microblink.Intent;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(MicroblinkScannerFactoryImplementation))]
namespace Microblink.Forms.Droid
{
    public interface IMicroblinkScannerAndroidHostActivity
    {
        /// <summary>
        /// Returns the host activity that is currently in use.
        /// </summary>
        /// <value>The host activity.</value>
        Activity HostActivity { get; }

        /// <summary>
        /// Gets the scan activity request code. You can define your custom request code
        /// so that it will not interfere with request codes your app uses with other
        /// activities.
        /// </summary>
        /// <value>The scan activity request code.</value>
        int ScanActivityRequestCode { get; }

        /// <summary>
        /// This method is called from Android's version of MicroblinkScannerImplementation at
        /// the time when scanning will be started. You should save the implementation's object
        /// reference here and use it in OnActivityResult method to forward that event to it.
        /// </summary>
        /// <param name="implementation">Implementation.</param>
        void ScanningStarted(MicroblinkScannerImplementation implementation);
    }

    public sealed class MicroblinkScannerImplementation : IMicroblinkScanner
    {
        IMicroblinkScannerAndroidHostActivity androidHostActivity;

        RecognizerBundle recognizerBundle;

        public MicroblinkScannerImplementation(string licenseKey, string licensee, bool showTimeLimitedLicenseWarning, IMicroblinkScannerAndroidHostActivity androidHostActivity) 
        {
            this.androidHostActivity = androidHostActivity;
            MicroblinkSDK.SetShowTimeLimitedLicenseWarning(showTimeLimitedLicenseWarning);
            if (licensee == null)
            {
                MicroblinkSDK.SetLicenseKey(licenseKey, androidHostActivity.HostActivity);
            }
            else
            {
                MicroblinkSDK.SetLicenseKey(licenseKey, licensee, androidHostActivity.HostActivity);
            }
            MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;

        }

        public void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == androidHostActivity.ScanActivityRequestCode)
            {
                if (resultCode == Result.Ok) 
                {
                    if (recognizerBundle != null)
                    {
                        recognizerBundle.LoadFromIntent(data);
                    }
                    MessagingCenter.Send(new Messages.ScanningDoneMessage { ScanningCancelled = false }, Messages.ScanningDoneMessageId);
                } 
                else
                {
                    MessagingCenter.Send(new Messages.ScanningDoneMessage { ScanningCancelled = true }, Messages.ScanningDoneMessageId);
                }
            }
        }

        public void Scan(IOverlaySettings overlaySettings)
        {
            recognizerBundle = null;

            androidHostActivity.ScanningStarted(this);
            var aOverlaySettings = (OverlaySettings)overlaySettings;

            // assume given recognizerCollection was also used for constructing overlaySettings
            recognizerBundle = ((RecognizerCollection)((RecognizerCollectionOverlaySettings)aOverlaySettings).RecognizerCollection).NativeRecognizerBundle;
            ActivityRunner.StartActivityForResult(androidHostActivity.HostActivity, androidHostActivity.ScanActivityRequestCode, ((OverlaySettings)overlaySettings).NativeUISettings);
        }
    }

    public sealed class MicroblinkScannerFactoryImplementation : IMicroblinkScannerFactory
    {
        /// <summary>
        /// Set this to your implementation of IMicroblinkScannerAndroidHostActivity interface before
        /// calling CreateMicroblinkScanner method.
        /// </summary>
        /// <value>The android host activity.</value>
        public static IMicroblinkScannerAndroidHostActivity AndroidHostActivity { get; set; }

        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, bool showTimeLimitedLicenseWarning)
        {
            if (AndroidHostActivity == null) {
                throw new NullReferenceException("Please set AndroidHostActivity implementation in your Droid project.");
            }
            return new MicroblinkScannerImplementation(licenseKey, null, showTimeLimitedLicenseWarning, AndroidHostActivity);
        }

        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee, bool showTimeLimitedLicenseWarning)
        {
            if (AndroidHostActivity == null)
            {
                throw new NullReferenceException("Please set AndroidHostActivity implementation in your Droid project.");
            }
            return new MicroblinkScannerImplementation(licenseKey, licensee, showTimeLimitedLicenseWarning, AndroidHostActivity);
        }
    }
}
