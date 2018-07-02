using Xamarin.Forms;
using Microblink.Forms.iOS;
using UIKit;
using Microblink.Forms.Shared.Overlays;
using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.Shared;

[assembly: Xamarin.Forms.Dependency (typeof (MicroblinkScannerImplementation))]
[assembly: Xamarin.Forms.Dependency(typeof(MicroblinkScannerFactoryImplementation))]
namespace Microblink.Forms.iOS
{
	public sealed class MicroblinkScannerImplementation : IMicroblinkScanner, IOverlayVCDelegate
	{
        // ensure RecognizerRunnerVC does not get GC-ed while it is required for ObjC code
        IMBRecognizerRunnerViewController recognizerRunnerViewController;

        public MicroblinkScannerImplementation(string licenseKey, string licensee)
        {
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
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;

            recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(((OverlaySettings)overlaySettings).CreateOverlayViewController(this));

            vc.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
        }

        public void ScanningFinished(MBOverlayViewController overlayViewController, MBRecognizerResultState state)
        {
            overlayViewController.RecognizerRunnerViewController.PauseScanning();

            UIApplication.SharedApplication.InvokeOnMainThread(delegate {
                MessagingCenter.Send(new Microblink.Forms.Shared.Messages.ScanningDoneMessage { ScanningCancelled = false }, Microblink.Forms.Shared.Messages.ScanningDoneMessageId);
                overlayViewController.DismissViewController(true, null);
            });
        }

        public void CloseButtonTapped(MBOverlayViewController overlayViewController)
        {
            MessagingCenter.Send(new Microblink.Forms.Shared.Messages.ScanningDoneMessage { ScanningCancelled = true }, Microblink.Forms.Shared.Messages.ScanningDoneMessageId);
            overlayViewController.DismissViewController(true, null);
        }

    }

    public sealed class MicroblinkScannerFactoryImplementation : IMicroblinkScannerFactory
    {
        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey)
        {
            return new MicroblinkScannerImplementation(licenseKey, null);
        }

        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee)
        {
            return new MicroblinkScannerImplementation(licenseKey, licensee);
        }
    }
}

