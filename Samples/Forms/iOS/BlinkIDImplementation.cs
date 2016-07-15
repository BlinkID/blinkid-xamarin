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
		bool isFrontCamera;

		public BlinkIDImplementation ()
		{
			CustomDelegate customDelegate = new CustomDelegate ();

			BlinkID.Instance ().LicenseKey = "UMGPSARL-P3ZZKNXF-36HDYAI5-A4SLTUAL-J5UJ4ODX-BRIIUIH2-5OZFQ4QQ-HSCSLD77";
			BlinkID.Instance ().Delegate = customDelegate;

			//BlinkID.Instance ().AddMrtdRecognizer ();
			//BlinkID.Instance ().AddEudlRecognizer ();
			//BlinkID.Instance ().AddCroIdFrontRecognizer ();
			//BlinkID.Instance ().AddCroIdBackRecognizer ();
			//BlinkID.Instance ().AddAusIDBackRecognizer ();
			//BlinkID.Instance ().AddAusIDBackRecognizer ();
			//BlinkID.Instance ().AddBarDecoderRecognizer ();
			//BlinkID.Instance ().AddCzIDFrontRecognizer ();
			//BlinkID.Instance ().AddCzIDBackRecognizer ();
			//BlinkID.Instance ().AddDedlRecognizer ();
			//BlinkID.Instance ().AddEudlRecognizer ();
			//BlinkID.Instance ().AddMyKadRecognizer ();
			//BlinkID.Instance ().AddPdf417Recognizer ();
			//BlinkID.Instance ().AddSingaporeIDRecognizer ();
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

