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

			BlinkID.Instance().LicenseKey = "5NXBHL7Z-D2IXPPFK-SSFOGINA-NPBXL65S-OKKJP3P7-U75K533D-T55QTZRC-ZCTY3JVS";
			BlinkID.Instance().Delegate = customDelegate;

			BlinkID.Instance ().AddMrtdRecognizer ();

			//BlinkID.Instance ().AddEudlRecognizer ();
			//BlinkID.Instance ().AddGerMrzRecognizer ();
			//BlinkID.Instance ().AddGerIDFrontRecognizer ();
			//BlinkID.Instance ().AddCroIdFrontRecognizer ();
			//BlinkID.Instance ().AddCroIdBackRecognizer ();
			//BlinkID.Instance ().AddAusIDFrontRecognizer ();
			//BlinkID.Instance ().AddAusIDBackRecognizer ();
			//BlinkID.Instance ().AddBarDecoderRecognizer ();
			//BlinkID.Instance ().AddCzIDFrontRecognizer ();
			//BlinkID.Instance ().AddCzIDBackRecognizer ();
			//BlinkID.Instance ().AddDedlRecognizer ();
			//BlinkID.Instance ().AddEudlRecognizer ();
			//BlinkID.Instance ().AddMyKadRecognizer ();
			//BlinkID.Instance ().AddIKadRecognizer ();
			//BlinkID.Instance ().AddPdf417Recognizer ();
			//BlinkID.Instance ().AddSingaporeIDRecognizer ();
			//BlinkID.Instance ().AddUkdlRecognizer ();
			//BlinkID.Instance ().AddSerbIDFrontRecognizer ();
			//BlinkID.Instance ().AddSerbIDBackRecognizer ();
			//BlinkID.Instance ().AddSlovakIDFrontRecognizer ();
			//BlinkID.Instance ().AddSlovakIDBackRecognizer ();
			//BlinkID.Instance ().AddSlovenianIDFrontRecognizer ();
			//BlinkID.Instance ().AddSlovenianIDBackRecognizer ();
			//BlinkID.Instance ().AddSingaporeIDFrontRecognizer ();
			//BlinkID.Instance ().AddSingaporeIDBackRecognizer ();
			//BlinkID.Instance ().AddUsdlRecognizer ();
			//BlinkID.Instance ().AddAusdlRecognizer ();
			//BlinkID.Instance ().AddZXingRecognizer ();

			//BlinkID.Instance ().AddVinParser ("VIN_PARSER_ID");
			//BlinkID.Instance ().AddLicensePlatesParser ("LICENSE_PLATES_PARSER_ID");

			//BlinkID.Instance ().AddTopUpOcrParser ("TOP_UP_OCR_PARSER_ID");
			//BlinkID.Instance ().AddRegexParser ("Blink\\d\\d\\d", "REGEX_PARSER_ID");
			//BlinkID.Instance ().AddIbanParser ("IBAN_PARSER_ID");
			//BlinkID.Instance ().AddEmailParser ("EMAIL_PARSER_ID");
			//BlinkID.Instance ().AddDateParser ("DATE_PARSER_ID");
			//BlinkID.Instance ().AddRawParser ("RAW_PARSER_ID");
			//BlinkID.Instance ().AddAmountParser ("AMOUNT_PARSER_ID");

			//BlinkID.Instance ().AddIdCardDetector ();

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

