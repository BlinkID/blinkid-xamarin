using Xamarin.Forms;
using BlinkIDFormsSample.iOS;
using UIKit;
using Microblink;
using BlinkIDApp;
using BlinkIDFormsSample.Overlays;
using BlinkIDFormsSample.iOS.Overlays;

[assembly: Xamarin.Forms.Dependency (typeof (BlinkIDImplementation))]
namespace BlinkIDFormsSample.iOS
{
	public class BlinkIDImplementation : IBlinkID, IOverlayVCDelegate
	{
        // ensure RecognizerRunnerVC does not get GC-ed while it is required for ObjC code
        IMBRecognizerRunnerViewController recognizerRunnerViewController;

        #pragma warning disable RECS0029 // Warns about property or indexer setters and event adders or removers that do not use the value parameter
        public string AndroidLicenseKey { get => null; set { } }
        #pragma warning restore RECS0029 // Warns about property or indexer setters and event adders or removers that do not use the value parameter

        string licenseKey;

        public string IosLicenseKey
        {
            get => licenseKey;
            set
            {
                licenseKey = value;
                MBMicroblinkSDK.SharedInstance.SetLicenseKey(licenseKey);
            }
        }

        public void Scan(IOverlaySettings overlaySettings)
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;

            recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(((OverlaySettings)overlaySettings).CreateOverlayViewController(this));

            vc.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
        }

        public void ScanningFinished(MBOverlayViewController overlayViewController, MBRecognizerResultState state)
        {
            overlayViewController.RecognizerRunnerViewController.PauseScanning();

            UIApplication.SharedApplication.InvokeOnMainThread(delegate {
                MessagingCenter.Send(new BlinkIDApp.Messages.ScanningDoneMessage { ScanningCancelled = false }, BlinkIDApp.Messages.ScanningDoneMessageId);
                overlayViewController.DismissViewController(true, null);
            });
        }

        public void CloseButtonTapped(MBOverlayViewController overlayViewController)
        {
            MessagingCenter.Send(new BlinkIDApp.Messages.ScanningDoneMessage { ScanningCancelled = true }, BlinkIDApp.Messages.ScanningDoneMessageId);
            overlayViewController.DismissViewController(true, null);
        }

    }
}

