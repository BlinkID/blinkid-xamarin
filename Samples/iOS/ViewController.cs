using System;

using UIKit;
using Foundation;
using System.Diagnostics;

using MicroBlink;

namespace iOS
{
	public partial class ViewController : UIViewController
	{
		bool isFrontCamera;
		CustomDelegate customDelegate;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			customDelegate = new CustomDelegate ();

			BlinkID.Instance().LicenseKey = "VVBZXXL4-YIHNFMHI-V3RF6KDA-WPFHFFEX-5X72P6VO-55RZ66YJ-IYVFVAOY-MYETCD5W";
			BlinkID.Instance().Delegate = customDelegate;

			//BlinkID.Instance ().AddMrtdRecognizer ();
			//BlinkID.Instance ().AddEudlRecognizer ();
			//BlinkID.Instance ().AddCroIdFrontRecognizer ();
			//BlinkID.Instance ().AddCroIdBackRecognizer ();
			//BlinkID.Instance ().AddAusIDFrontRecognizerSettings ();
			//BlinkID.Instance ().AddAusIDBackRecognizerSettings ();
			//BlinkID.Instance ().AddBarDecoderRecognizer ();
			//BlinkID.Instance ().AddCzIDFrontRecognizer ();
			//BlinkID.Instance ().AddCzIDBackRecognizer ();
			//BlinkID.Instance ().AddDedlRecognizer ();
			//BlinkID.Instance ().AddEudlRecognizer ();
			//BlinkID.Instance ().AddMyKadRecognizer ();
			//BlinkID.Instance ().AddPdf417Recognizer ();
			//BlinkID.Instance ().AddSingaporeIDRecognizerSettings ();
			//BlinkID.Instance ().AddUkdlRecognizer ();
			//BlinkID.Instance ().AddUsdlRecognizer ();
			//BlinkID.Instance ().AddZXingRecognizer ();

			//BlinkID.Instance ().AddVinParser ("");
			//BlinkID.Instance ().AddRegexParser ("", "");
			//BlinkID.Instance ().AddIbanParser ("");
			//BlinkID.Instance ().AddEmailParser ("");
			//BlinkID.Instance ().AddDateParser ("");
			//BlinkID.Instance ().AddRawParser ("");
			//BlinkID.Instance ().AddAmountParser ("");

			BlinkID.Instance ().AddIdCardDetector ();

			//BlinkID.Instance ().ClearAllDetectors ();
			//BlinkID.Instance ().ClearAllParsers ();
			//BlinkID.Instance ().ClearAllRecognizers ();

			isFrontCamera = false;

			customDelegate.MetadataImageView = metadataImageView;
			customDelegate.MetadataTextView = metadataTextView;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void StartScanningButton_TouchUpInside (UIButton sender)
		{
			BlinkID.Instance().Scan(isFrontCamera);
		}

		class CustomDelegate : BlinkIDDelegate
		{
			public UIImageView MetadataImageView {
				get; set;
			}

			public UITextView MetadataTextView {
				get; set;
			}

			#region implemented abstract members of BlinkIDDelegate

			public override void DidOutputResults (BlinkID blinkid, NSDictionary[] results)
			{
				UIAlertView alert = new UIAlertView () { 
					Title = "BlinkID results", Message = results[0].ToString()
				};
				alert.AddButton("OK");
				alert.Show ();
			}

			public override void DidOutputImage (BlinkID blinkid, UIImage image, string name)
			{
				MetadataImageView.Image = image;
				MetadataTextView.Text = name;
			}

			#endregion
		}
	}
}

