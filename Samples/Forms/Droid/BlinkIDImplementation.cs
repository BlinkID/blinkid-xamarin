using BlinkIDApp.Droid;
using Xamarin.Forms;
using BlinkIDFormsSample.Overlays;
using BlinkIDFormsSample.Recognizers;
using Com.Microblink;
using Com.Microblink.Uisettings;
using BlinkIDFormsSample.Droid.Overlays;
using Com.Microblink.Entities.Recognizers;
using Android.App;
using Android.Content;
using BlinkIDFormsSample.Droid.Recognizers;
using Com.Microblink.Intent;

[assembly: Xamarin.Forms.Dependency (typeof (BlinkIDImplementation))]
namespace BlinkIDApp.Droid
{
	public class BlinkIDImplementation : IBlinkID
	{
        const int REQUEST_CODE = 101;

        RecognizerBundle recognizerBundle;

        public BlinkIDImplementation() 
        {
            MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;
        }

        public void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == REQUEST_CODE)
            {
                if (resultCode == Result.Ok) 
                {
                    recognizerBundle.LoadFromIntent(data);
                    MessagingCenter.Send(new Messages.ScanningDoneMessage { ScanningCancelled = false }, Messages.ScanningDoneMessageId);
                } 
                else
                {
                    MessagingCenter.Send(new Messages.ScanningDoneMessage { ScanningCancelled = true }, Messages.ScanningDoneMessageId);
                }
            }
            MainActivity.Instance.BlinkIDImplementation = null;
        }

        #region IBlinkID implementation

        private string licenseKey;

        public string AndroidLicenseKey
        {
            get => licenseKey;
            set
            {
                licenseKey = value;
                MicroblinkSDK.SetLicenseKey(licenseKey, MainActivity.Instance);
            }
        }

#pragma warning disable RECS0029 // Warns about property or indexer setters and event adders or removers that do not use the value parameter
        public string IosLicenseKey { get => null; set {} }
#pragma warning restore RECS0029 // Warns about property or indexer setters and event adders or removers that do not use the value parameter

        public void Scan(IOverlaySettings overlaySettings)
        {
            MainActivity.Instance.BlinkIDImplementation = this;
            var aOverlaySettings = (OverlaySettings)overlaySettings;
            // assume given recognizerColelction was also used for constructing overlaySettings
            recognizerBundle = ((RecognizerCollection)aOverlaySettings.RecognizerCollection).NativeRecognizerBundle;
            ActivityRunner.StartActivityForResult(MainActivity.Instance, REQUEST_CODE, ((OverlaySettings)overlaySettings).NativeUISettings);
        }

        #endregion
    }
}

