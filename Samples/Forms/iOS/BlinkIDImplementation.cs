using System;
using Foundation;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using BlinkIDApp.iOS;
using UIKit;
using MicroBlink;

[assembly: Xamarin.Forms.Dependency (typeof (BlinkIDImplementation))]
namespace BlinkIDApp.iOS
{
	public class BlinkIDImplementation : IBlinkID
	{
		CustomDelegate customDelegate;
		bool isFrontCamera;

		public BlinkIDImplementation ()
		{
			customDelegate = new CustomDelegate ();

			BlinkID.Instance ().LicenseKey = "PYIECP3J-XHJMFSKH-XXPEIG62-R7634IH2-5OZFR4WV-XYQPV25S-LDZNKHXW-CLLJIJF5";
			BlinkID.Instance ().Delegate = customDelegate;

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
		}

		class CustomDelegate : BlinkIDDelegate
		{
			#region implemented abstract members of BlinkIDDelegate

			public override void DidOutputResults (BlinkID blinkid, NSDictionary [] results)
			{
				// Transform results from NSDictionary[] to List<Dictionary<string, string>>
				var transformedResults = new List<Dictionary<string, string>> ();

				foreach (var result in results) {
					var dict = new Dictionary<string, string> ();

					foreach (var item in result) {
						dict.Add (item.Key.ToString (), item.Value.ToString ());
					}

					transformedResults.Add (dict);
				}

				// Send results to subscribers
				MessagingCenter.Send (new Messages.BlinkIDResults {
					Results = transformedResults
				}, Messages.BlinkIDResultsMessage);
			}

			public override void DidOutputImage (BlinkID blinkid, UIImage image, string name)
			{
				MessagingCenter.Send (new Messages.BlinkIDImage {
					Image = ImageSource.FromStream (() => image.AsPNG ().AsStream ())
				}, Messages.BlinkIDImageMessage);
			} 

			#endregion
		}

		#region IBlinkID implementation

		public void Scan ()
		{
			Debug.WriteLine ("Native Scan is started");
			BlinkID.Instance ().Scan (isFrontCamera);
		}

		#endregion
	}
}

