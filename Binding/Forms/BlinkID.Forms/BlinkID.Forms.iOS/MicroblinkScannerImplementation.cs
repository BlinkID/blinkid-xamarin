using Xamarin.Forms;
using BlinkID.Forms.iOS;
using UIKit;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.iOS.Overlays;
using BlinkID.Forms.Core.Recognizers;
using BlinkID.Forms.Core;
using BlinkID.Forms.iOS.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MicroblinkScannerFactoryImplementation))]
namespace BlinkID.Forms.iOS
{
    public sealed class MicroblinkScannerImplementation : IMicroblinkScanner, IOverlayVCDelegate
    {
        // ensure RecognizerRunnerVC does not get GC-ed while it is required for ObjC code
        IMBRecognizerRunnerViewController recognizerRunnerViewController;
        // ensure OverlaySettings don't get GC-ed while they are required for ObjC code
        IOverlaySettings overlaySettings;

        public MicroblinkScannerImplementation(string licenseKey, string licensee, bool showTrialLicenseWarning)
        {
            MBMicroblinkSDK.SharedInstance().ShowTrialLicenseWarning = showTrialLicenseWarning;
            if (licensee == null)
            {
                MBMicroblinkSDK.SharedInstance().SetLicenseKey(licenseKey, (licenseError) => {
                    // here, you can check license error
                });
            }
            else
            {
                MBMicroblinkSDK.SharedInstance().SetLicenseKey(licenseKey, licensee, (licenseError) => {
                    // here, you can check license error
                });
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
                MessagingCenter.Send(new BlinkID.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = false }, BlinkID.Forms.Core.Messages.ScanningDoneMessageId);
                overlayViewController.DismissViewController(true, null);
            });
        }

        public void CloseButtonTapped(MBOverlayViewController overlayViewController)
        {
            MessagingCenter.Send(new BlinkID.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = true }, BlinkID.Forms.Core.Messages.ScanningDoneMessageId);
            overlayViewController.DismissViewController(true, null);
        }

    }

    public sealed class MicroblinkScannerFactoryImplementation : IMicroblinkScannerFactory
    {
        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, bool showTrialLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, null, showTrialLicenseWarning);
        }

        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee, bool showTrialLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, licensee, showTrialLicenseWarning);
        }
    }
}