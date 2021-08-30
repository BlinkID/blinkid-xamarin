using System;

using UIKit;

using BlinkID;

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

            // set license key for iOS with bundle ID com.microblink.sample
            MBMicroblinkSDK.SharedInstance().SetLicenseKey("sRwAAAEVY29tLm1pY3JvYmxpbmsuc2FtcGxl1BIcP4FpSuS/38JVOjalnIUAO6GSoXBJSnE8F0QDNJHKEMH7o9ipBUa6gs9JVUn1xhlm+gU+CE8M5dfpDJ5dThQAwhdat7lEBlhqCWhhVnaFAwhRPzmGoBT5DPJH+/j0bMsP52KFNDIQyjJ56+N/rtC1NQc0A/5weRzGQ0mJCESXhL1iCYi/ewtO8VmzBIMsPHcbtNKVqSabeqBOvjKVdwCDodUHYD4gxp+Z5QGjWEUTqqubZcRckHLEq+55y3IRpBev7y2ZfrwTPTBvkg6icvXZzpYl9G7UQnJfsx90JCFnGbFwkzgtCyG0D4EgWxpW2TRBZU9REHXXGZqh9BdHGCmv", null);
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
                if (me.blinkIdRecognizer.Result.ResultState == MBRecognizerResultState.Valid) {
                    var blinkidResult = me.blinkIdRecognizer.Result;
                    message += "BlinkID recognizer result:\n" +
                        BuildResult(blinkidResult.FirstName, "First name") +
                        BuildResult(blinkidResult.LastName, "Last name") +
                        BuildResult(blinkidResult.FullName, "Full name") +
                        BuildResult(blinkidResult.LocalizedName, "Localized name") +
                        BuildResult(blinkidResult.AdditionalNameInformation, "Additional name info") +
                        BuildResult(blinkidResult.Address, "Address") +
                        BuildResult(blinkidResult.AdditionalAddressInformation, "Additional address info") +
                        BuildResult(blinkidResult.DocumentNumber, "Document number") +
                        BuildResult(blinkidResult.DocumentAdditionalNumber, "Additional document number") +
                        BuildResult(blinkidResult.Sex, "Sex") +
                        BuildResult(blinkidResult.IssuingAuthority, "Issuing authority") +
                        BuildResult(blinkidResult.Nationality, "Nationality") +
                        BuildResult(blinkidResult.DateOfBirth, "DateOfBirth") +
                        BuildResult(blinkidResult.Age, "Age") +
                        BuildResult(blinkidResult.DateOfIssue, "Date of issue") +
                        BuildResult(blinkidResult.DateOfExpiry, "Date of expiry") +
                        BuildResult(blinkidResult.DateOfExpiryPermanent, "Date of expiry permanent") +
                        BuildResult(blinkidResult.MaritalStatus, "Martial status") +
                        BuildResult(blinkidResult.PersonalIdNumber, "Personal Id Number") +
                        BuildResult(blinkidResult.Profession, "Profession") +
                        BuildResult(blinkidResult.Race, "Race") +
                        BuildResult(blinkidResult.Religion, "Religion") +
                        BuildResult(blinkidResult.ResidentialStatus, "Residential Status");

                    MBDriverLicenseDetailedInfo licenceInfo = blinkidResult.DriverLicenseDetailedInfo;
                    if (licenceInfo != null)
                    {
                        message +=
                            BuildResult(licenceInfo.Restrictions, "Restrictions") +
                            BuildResult(licenceInfo.Endorsements, "Endorsements") +
                            BuildResult(licenceInfo.VehicleClass, "Vehicle class") +
                            BuildResult(licenceInfo.Conditions, "Conditions");
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

            private string BuildResult(string result, string propertyName)
            {
                if (result == null || result.Length == 0)
                {
                    return "";
                }

                return propertyName + ": " + result + "\n";
            }

            private string BuildResult(Boolean result, string propertyName)
            {
                if (result)
                {
                    return propertyName + ": YES" + "\n";
                }

                return propertyName + ": NO" + "\n";
            }

            private string BuildResult(int result, string propertyName)
            {
                if (result < 0)
                {
                    return "";
                }

                return propertyName + ": " + result + "\n";
            }

            private string BuildResult(MBDateResult result, string propertyName)
            {
                if (result == null || result.Year == 0)
                {
                    return "";
                }

                DateTime date = new DateTime(Convert.ToInt32(result.Year),
                                            Convert.ToInt32(result.Month),
                                            Convert.ToInt32(result.Day));
                return propertyName + ": " + date.ToShortDateString() + "\n";
            }
        }
	}
}