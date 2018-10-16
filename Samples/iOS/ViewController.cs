using System;

using UIKit;

using Microblink;

namespace iOS
{
	public partial class ViewController : UIViewController
	{
        // MBMrtdRecognizer is used for scanning Machine Readable Travel Documents
        MBMrtdRecognizer mrtdRecognizer;

        // MBEudlRecognizer is used for scanning EU Driver's licenses
        MBEudlRecognizer eudlRecognizer;

        // MBUsdlRecognizer is used for scanning PDF417 barcode on back side of
        // US Driver's licenses
        MBUsdlRecognizer usdlRecognizer;

        // there are plenty of recognizers available - see iOS documentation
        // for more information: https://github.com/BlinkID/blinkid-ios/blob/master/README.md

        CustomDelegate customDelegate;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

            customDelegate = new CustomDelegate(this);

            // set license key for iOS with bundle ID com.microblink.xamarin.blinkid
            MBMicroblinkSDK.SharedInstance.SetLicenseKey("sRwAAAEeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lks3unDF2B9jpa6FeAxSjaWUg1ROYBfuTUj5ciQyp9KpRtdClsjclAqYTT1BA7QMj6tUv6yIwdGZNSUhiR253O9Zugyv6tsc8hB9XvpMvDAHOiAmgzkj5SacPTjp5C4xZwKCmER2NUf4YSDddznrI7btd5cNnr0Bc5lT0wNHzlN7Z6r04dqoI+jzrCW65IgF8DrA/t4C6O0/lxthm+IfAmobL0kfI0ui6/fy3m8OZ31AacLKO1qb4T0A==");

            mrtdRecognizer = new MBMrtdRecognizer();
            usdlRecognizer = new MBUsdlRecognizer();
            eudlRecognizer = new MBEudlRecognizer();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void StartScanningButton_TouchUpInside (UIButton sender)
		{
            // create a collection of recognizers that will be used for scanning
            var recognizerCollection = new MBRecognizerCollection(new MBRecognizer[] { mrtdRecognizer, eudlRecognizer, usdlRecognizer });

            // create a settings object for overlay that will be used. For ID it's best to use DocumentOverlayViewController
            // there are also other overlays available - check iOS documentation
            var documentOverlaySettings = new MBDocumentOverlaySettings();
            var documentOverlay = new MBDocumentOverlayViewController(documentOverlaySettings, recognizerCollection, customDelegate);

            // finally, create a recognizerRunnerViewController
            var recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(documentOverlay);

            // in ObjC recognizerRunnerViewController would actually be of type UIViewController<MBRecognizerRunnerViewController>*, but this construct
            // is not supported in C#, so we need to use Runtime.GetINativeObject to cast obtained IMBReocognizerRunnerViewController into UIViewController
            // that can be presented
            this.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
		}

        class CustomDelegate : MBDocumentOverlayViewControllerDelegate
        {
            ViewController me;

            public CustomDelegate(ViewController me)
            {
                this.me = me;
            }

            public override void DocumentOverlayViewControllerDidFinishScanning(MBDocumentOverlayViewController documentOverlayViewController, MBRecognizerResultState state)
            {
                // this method is called on background processing thread. The scanning will resume as soon
                // as this method ends, so in order to have unchanged results at the time of displaying UIAlertView
                // pause the scanning
                documentOverlayViewController.RecognizerRunnerViewController.PauseScanning();

                var title = "Result";
                var message = "";

                // each recognizer has Result property which contains recognized data after scanning has been finished

                // we can check ResultState property of the Result to see if the result contains scanned information
                if (me.mrtdRecognizer.Result.ResultState == MBRecognizerResultState.Valid) {
                    var mrtdResult = me.mrtdRecognizer.Result;
                    message += "MRTD recognizer result:\n" +
                        "PrimaryID: " + mrtdResult.MrzResult.PrimaryID + "\n" +
                         "SecondaryID: " + mrtdResult.MrzResult.SecondaryID + "\n" +
                         "Date of birth: " + mrtdResult.MrzResult.DateOfBirth.Day + "." +
                                             mrtdResult.MrzResult.DateOfBirth.Month + "." +
                                             mrtdResult.MrzResult.DateOfBirth.Year + ".\n";
                }
                if (me.eudlRecognizer.Result.ResultState == MBRecognizerResultState.Valid) {
                    var eudlResult = me.eudlRecognizer.Result;
                    message += "EUDL recognizer result:\n" +
                       "First name: " + eudlResult.FirstName + "\n" +
                       "Last name: " + eudlResult.LastName + "\n" +
                       "Birth data: " + eudlResult.BirthData + "\n" +
                       "Country: " + eudlResult.Country.ToString() + "\n";
                }
                if (me.usdlRecognizer.Result.ResultState == MBRecognizerResultState.Valid) {
                    var usdlResult = me.usdlRecognizer.Result;
                    message += "USDL recognizer result:\n" +
                           "First name: " + usdlResult.GetField(MBUsdlKeys.CustomerFirstName) + "\n" +
                           "Last name: " + usdlResult.GetField(MBUsdlKeys.CustomerFamilyName) + "\n" +
                           "City: " + usdlResult.GetField(MBUsdlKeys.AddressCity) + "\n";
                }

                UIApplication.SharedApplication.InvokeOnMainThread(delegate
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = title,
                        Message = message
                    };
                    alert.AddButton("OK");
                    alert.Show();
                    // after alert dialog is dismissed, you can either resume scanning with 
                    // documentOverlayViewController.RecognizerRunnerViewController.ResumeScanningAndResetState(true)
                    // or you can simply dismiss the RecognizerRunnerViewController
                    alert.Dismissed += (sender, e) => me.DismissViewController(true, null);
                });

            }

            public override void DocumentOverlayViewControllerDidTapClose(MBDocumentOverlayViewController documentOverlayViewController)
            {
                me.DismissViewController(true, null);
            }
        }
	}
}

