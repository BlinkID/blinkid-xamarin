using Xamarin.Forms;
using Microblink.Forms.iOS;
using UIKit;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Core;
using Microblink.Forms.iOS.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MicroblinkScannerFactoryImplementation))]
namespace Microblink.Forms.iOS
{
    public sealed class MicroblinkScannerImplementation : IMicroblinkScanner, IOverlayVCDelegate
    {
        // ensure RecognizerRunnerVC does not get GC-ed while it is required for ObjC code
        IMBRecognizerRunnerViewController recognizerRunnerViewController;
        // ensure OverlaySettings don't get GC-ed while they are required for ObjC code
        IOverlaySettings overlaySettings;

        MBImage highResImage;

        public MicroblinkScannerImplementation(string licenseKey, string licensee, bool showTimeLimitedLicenseWarning)
        {
            MBMicroblinkSDK.SharedInstance.ShowLicenseKeyTimeLimitedWarning = showTimeLimitedLicenseWarning;
            if (licensee == null) 
            {
                MBMicroblinkSDK.SharedInstance.SetLicenseKey(licenseKey);
            }
            else
            {
                MBMicroblinkSDK.SharedInstance.SetLicenseKey(licenseKey, licensee);
            }
        }

        public void Scan(IOverlaySettings overlaySettings)
        {
            this.overlaySettings = overlaySettings;
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;

            recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(((OverlaySettings)overlaySettings).CreateOverlayViewController(this));

            vc.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
        }

        public void ScanningFinished(MBOverlayViewController overlayViewController, MBRecognizerResultState state)
        {
            overlayViewController.RecognizerRunnerViewController.PauseScanning();

            UIApplication.SharedApplication.InvokeOnMainThread(delegate {
                MessagingCenter.Send(new Microblink.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = false }, Microblink.Forms.Core.Messages.ScanningDoneMessageId);
                overlayViewController.DismissViewController(true, null);
            });
        }

        public void CloseButtonTapped(MBOverlayViewController overlayViewController)
        {
            MessagingCenter.Send(new Microblink.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = true }, Microblink.Forms.Core.Messages.ScanningDoneMessageId);
            overlayViewController.DismissViewController(true, null);
        }

        public void ScanningFinishedWithHighResolutionImage(MBOverlayViewController overlayViewController, MBImage highResImage, MBRecognizerResultState state) 
        {
        }

    }

    public sealed class MicroblinkScannerFactoryImplementation : IMicroblinkScannerFactory
    {
        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, bool showTimeLimitedLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, null, showTimeLimitedLicenseWarning);
        }

        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee, bool showTimeLimitedLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, licensee, showTimeLimitedLicenseWarning);
        }
    }
}

