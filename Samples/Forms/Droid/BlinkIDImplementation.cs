using System;
using BlinkIDApp;
using BlinkIDApp.Droid;
using Com.Microblink.Wrapper.Xamarin;
using System.Collections.Generic;
using Android.Content;
using Xamarin.Forms;
using System.Diagnostics;
using System.IO;
using Android.Graphics;
using Java.Nio;
using Android.Runtime;

[assembly: Xamarin.Forms.Dependency (typeof (BlinkIDImplementation))]
namespace BlinkIDApp.Droid
{
	public class BlinkIDImplementation : IBlinkID
	{
		public const string LICENSE_KEY = "NOOGNXGH-27RBJQZX-QRB44LL2-MRD2Y2R5-3WFDYUMW-F3LAQILF-2HJBFMOZ-MPZY7R66";

		BlinkID blinkId;
		BlinkIdScanSettings blinkIdScanSettings;

		MResultListener mResultListener;

		public BlinkIDImplementation ()
		{
			// Configure BlinkID
			blinkId = BlinkID.Instance;
			blinkId.SetContext(Android.App.Application.Context);
			blinkId.SetLicenseKey(LICENSE_KEY);

			mResultListener = new MResultListener ();

			blinkId.SetResultListener(mResultListener);

			// Init settings
			blinkIdScanSettings = new BlinkIdScanSettings (Android.App.Application.Context, BlinkIdScanSettings.DeviceCameraType.CameraBackface);

			blinkIdScanSettings.SetAllowMultipleScanResultsOnSingleImage (false);

			/**
			 * Define recognizers
			 */
			// MRTD(Machine Readable Travel Document)
			if (!blinkIdScanSettings.AddRecognizerMRTD ()) {
				Console.WriteLine ("RecognizerMRTD is not supported on current device and camera settings");
			}

			// Driving licenses
			// United States of America
			//if (!blinkIdScanSettings.AddRecognizerUSDL ()) {
			//	Console.WriteLine ("RecognizerUSDL is not supported");
			//}
			// United Kingdom
			//if (!blinkIdScanSettings.AddRecognizerUKDL ()) {
			//	Console.WriteLine ("RecognizerUKDL is not supported");
			//}
			// Germany
			//if (!blinkIdScanSettings.AddRecognizerDEDL ()) {
			//	Console.WriteLine ("RecognizerDEDL is not supported");
			//}
			// Austria
			//if (!blinkIdScanSettings.AddRecognizerAustrianDL ()) {
			//	Console.WriteLine ("RecognizerAustrianDL is not supported");
			//}
			// European Union
			//// NOTE: If you use UKDL and DEDL at the same time than it will fallback to EUDL and it will be same as
			//if (!blinkIdScanSettings.AddRecognizerEUDL ()) {
			//	Console.WriteLine ("RecognizerEUDL is not supported");
			//}

			// Singapore
			//if (!blinkIdScanSettings.AddRecognizerSingaporeId ()) {
			//	Console.WriteLine ("RecognizerSingaporeId is not supported");
			//}

			// Malaysia
			//if (!blinkIdScanSettings.AddRecognizerMyKad ()) {
			//	Console.WriteLine ("RecognizerMyKad is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerIKad ()) {
			//	Console.WriteLine ("RecognizerIKad is not supported");
			//}

			// Croatia
			//if (!blinkIdScanSettings.AddRecognizerCroatianIdFront ()) {
			//	Console.WriteLine ("RecognizerCroatianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCroatianIdBack ()) {
			//	Console.WriteLine ("RecognizerCroatianIdBack is not supported");
			//}

			// Austria
			//if (!blinkIdScanSettings.AddRecognizerAustrianIdFront ()) {
			//	Console.WriteLine ("RecognizerAustrianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerAustrianIdBack ()) {
			//	Console.WriteLine ("RecognizerAustrianIdBack is not supported");
			//}

			// Cezch Republic
			//if (!blinkIdScanSettings.AddRecognizerCzechIdFront ()) {
			//	Console.WriteLine ("RecognizerCzechIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCzechIdBack ()) {
			//	Console.WriteLine ("RecognizerCzechIdBack is not supported");
			//}

			// Germany
			//if (!blinkIdScanSettings.AddRecognizerGermanIdFront ()) {
			//	Console.WriteLine ("RecognizerGermanIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerGermanIdMrzSide ()) {
			//	Console.WriteLine ("RecognizerGermanIdMrzSide is not supported");
			//}

			// Serbia
			//if (!blinkIdScanSettings.AddRecognizerSerbianIdFront ()) {
			//	Console.WriteLine ("RecognizerSerbianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerSerbianIdBack ()) {
			//	Console.WriteLine ("RecognizerSerbianIdBack is not supported");
			//}

			// Slovakia
			//if (!blinkIdScanSettings.AddRecognizerSlovakIdFront ()) {
			//	Console.WriteLine ("RecognizerSlovakIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerSlovakIdBack ()) {
			//	Console.WriteLine ("RecognizerSlovakIdBack is not supported");
			//}

			// Slovenia
			//if (!blinkIdScanSettings.AddRecognizerSlovenianIdFront ()) {
			//	Console.WriteLine ("RecognizerSlovenianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerSlovenianIdBack ()) {
			//	Console.WriteLine ("RecognizerSlovenianIdBack is not supported");
			//}

			// Barcode regognizers
			//if (!blinkIdScanSettings.AddRecognizerPdf417 ()) {
			//	Console.WriteLine ("RecognizerPdf417 is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerBarDecoder ()) {
			//	Console.WriteLine ("RecognizerBarDecoder is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerZxing ()) {
			//	Console.WriteLine ("RecognizerZxing is not supported");
			//}

			/**
			 * Define parsers
			 */
			//if (!blinkIdScanSettings.AddParserAmount ("AMOUNT_PARSER_ID", true)) {
			//	Console.WriteLine ("ParserAmount is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserDate ("DATE_PARSER_ID", true)) {
			//	Console.WriteLine ("ParserDate is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserEmail ("EMAIL_PARSER_ID", true)) {
			//	Console.WriteLine ("ParserEmail is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserIBAN ("IBAN_PARSER_ID", true)) {
			//	Console.WriteLine ("ParserIBAN is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserRaw ("RAW_PARSER_ID", true)) {
			//	Console.WriteLine ("ParserRaw is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserRegex ("REGEX_PARSER_ID", "Blink\\d\\d\\d", true)) {
			//	Console.WriteLine ("ParserRegex is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserVIN ("VIN_PARSER_ID", true)) {
			//	Console.WriteLine ("ParserVIN is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserLicensePlates ("LICENSE_PLATES_PARSER_ID", true)) {
			//	Console.WriteLine ("ParserLicensePlates is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserMobileCoupons ("MOBILE_COUPONS_PARSER_ID", "123", 14, true)) {
			//	Console.WriteLine ("ParserMobileCoupons is not supported");
			//}

			//if (!blinkIdScanSettings.AddDetectorIdCard ()) {
			//	Console.WriteLine ("DetectorIdCard is not supported");
			//}
		}

		private class MResultListener : BlinkIdResultListener 
		{
			#region implemented abstract members of BlinkIdResultListener
			public override void OnResultsAvailable (IList<IDictionary<string, string>> results)
			{
				// Transform results from IList<IDictionary<string, string>> to List<Dictionary<string, string>>
				var transformedResults = new List<Dictionary<string, string>> ();

				foreach (var result in results) {
					var dict = new Dictionary<string, string> ();

					foreach (var item in result) {
						dict.Add (item.Key.ToString(), item.Value.ToString());
					}

					transformedResults.Add (dict);
				}

				MessagingCenter.Send<Messages.BlinkIDResults> (new Messages.BlinkIDResults {
					Results = transformedResults
				}, Messages.BlinkIDResultsMessage);

			}

			public override void OnDocumentImageAvailable (Bitmap document)
			{
				Console.WriteLine ("OnDocumentImageAvailable started " + DateTime.Now.Second);

				Bitmap bitmap = document;

				byte [] bitmapData;
				using (var stream = new MemoryStream ()) {
					bitmap.Compress (Bitmap.CompressFormat.Jpeg, 100, stream);
					Console.WriteLine ("OnDocumentImageAvailable compress finished " + DateTime.Now.Second);
					bitmapData = stream.ToArray ();
				}

				Console.WriteLine ("OnDocumentImageAvailable stream to array finished " + DateTime.Now.Second);

				MessagingCenter.Send (new Messages.BlinkIDImage {
					Image = ImageSource.FromStream (() => new MemoryStream (bitmapData))
				}, Messages.BlinkIDImageMessage);

				Console.WriteLine ("OnDocumentImageAvailable finished " + DateTime.Now.Second);

			}
			#endregion
		}

		#region IBlinkID implementation

		public void Scan ()
		{
			Debug.WriteLine ("Native Scan is started");
			try {
				blinkId.Scan (blinkIdScanSettings);
			} catch (IllegalScanSettingsException ex) {
				Debug.WriteLine (ex.Message);
			}
		}

		#endregion
	}
}

