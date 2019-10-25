using System;

using UIKit;

using Microblink;

namespace iOS
{
	public partial class ViewController : UIViewController
	{
		// MBBlinkIdRecognizer is used to scan all supported documents
		MBBlinkIdRecognizer blinkIdRecognizer;

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
            MBMicroblinkSDK.SharedInstance.SetLicenseKey("sRwAAAEeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lks3unDL+B9jpa6FeAwwR59En984J4Ii3FbxJsLnbDNmxYX1B6I2Wziz/GdpHQk8xYx/+WyaLzil0hiI2oRujoEfQawqvM/FGqhb154jOM8Azuj3p/P54XONjcVB8TjcEDdskWFBuH22Bw6iKCpUrj47CkWGFJb5vv+wQQW9DpF5wH04AnFETMVTsQdqDD2Mio7F3L+eu0xnKtPjyaT73NOHhNEsQDf17F5B+Q7Pd0spOPzGxvVvP73xrsam69NmbmQanB3n+ggL0=");
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void StartScanningButton_TouchUpInside (UIButton sender)
		{
            blinkIdRecognizer = new MBBlinkIdRecognizer();

            // create a collection of recognizers that will be used for scanning
            var recognizerCollection = new MBRecognizerCollection(new MBRecognizer[] { blinkIdRecognizer });

            // create a settings object for overlay that will be used. For ID it's best to use DocumentOverlayViewController
            // there are also other overlays available - check iOS documentation
            var blinkIdOverlaySettings = new MBBlinkIdOverlaySettings();
            var blinkIdOverlay = new MBBlinkIdOverlayViewController(blinkIdOverlaySettings, recognizerCollection, customDelegate);

            // finally, create a recognizerRunnerViewController
            var recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(blinkIdOverlay);

            // in ObjC recognizerRunnerViewController would actually be of type UIViewController<MBRecognizerRunnerViewController>*, but this construct
            // is not supported in C#, so we need to use Runtime.GetINativeObject to cast obtained IMBReocognizerRunnerViewController into UIViewController
            // that can be presented
            this.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
		}

        class CustomDelegate : MBBlinkIdOverlayViewControllerDelegate
        {
            ViewController me;

            public CustomDelegate(ViewController me)
            {
                this.me = me;
            }

            public override void BlinkIdOverlayViewControllerDidFinishScanning(MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state)
            {
				// this method is called on background processing thread. The scanning will resume as soon
				// as this method ends, so in order to have unchanged results at the time of displaying UIAlertView
				// pause the scanning
				blinkIdOverlayViewController.RecognizerRunnerViewController.PauseScanning();

                var title = "Result";
                var message = "";

                // each recognizer has Result property which contains recognized data after scanning has been finished

                // we can check ResultState property of the Result to see if the result contains scanned information
                if (me.blinkIdRecognizer.Result.ResultState == MBRecognizerResultState.Uncertain) {
                    var blinkidResult = me.blinkIdRecognizer.Result;
					message += "BlinkID recognizer result:\n" +
						"FirstName: " + blinkidResult.FirstName + "\n" +
						"LastName: " + blinkidResult.LastName + "\n" +
						"Address: " + blinkidResult.Address + "\n" +
						"DocumentNumber: " + blinkidResult.DocumentNumber + "\n" +
						"Sex: " + blinkidResult.Sex + "\n";
					var dob = blinkidResult.DateOfBirth;
					if (dob != null)
					{
						message +=
							"DateOfBirth: " + dob.Day + "." +
											  dob.Month + "." +
											  dob.Year + ".\n";
					}
					var doi = blinkidResult.DateOfIssue;
					if (doi != null)
					{
						message +=
							"DateOfIssue: " + doi.Day + "." +
											  doi.Month + "." +
											  doi.Year + ".\n";

					}
					var doe = blinkidResult.DateOfExpiry;
					if (doe != null)
					{
						message +=
							"DateOfExpiry: " + doe.Day + "." +
											   doe.Month + "." +
											   doe.Year + ".\n";

					}
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

            public override void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController)
            {
                me.DismissViewController(true, null);
            }
        }
	}
}

