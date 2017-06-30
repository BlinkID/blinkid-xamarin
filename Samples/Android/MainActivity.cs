using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using System.Diagnostics;
using Com.Microblink.Wrapper.Xamarin;
using System.Collections.Generic;
using Android.Content;
using System.Collections.ObjectModel;
using Android.Graphics;
using System.IO;
using Java.Lang;

namespace Android
{
	[Activity (Label = "BlinkID Xamarin", MainLauncher = true, Icon = "@mipmap/icon", HardwareAccelerated = true)]
	public class MainActivity : Activity
	{
		public const string LICENSE_KEY = "YXYKNFI6-IL7BPDQO-LWJTJLN4-ZV7RAXUH-F7QX4XUH-F7QX4XUH-F7QX57QA-DY33G5LK";
		BlinkID blinkId;
		BlinkIdScanSettings blinkIdScanSettings;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			RequestedOrientation = ScreenOrientation.Portrait;

			Button button = FindViewById<Button> (Resource.Id.startScanningButton);

			// Setup BlinkID before usage
			initBlinkId ();

			if (!BlinkID.Instance.IsBlinkIDSupportedOnDevice (this)) {
				button.Enabled = false;
				Toast.MakeText (this, "BlinkID is not supported!", ToastLength.Long).Show ();
			} else {
				button.Click += delegate {
					Console.WriteLine ("Native Scan is started");
					try {
						blinkId.Scan (blinkIdScanSettings);
					} catch (IllegalScanSettingsException ex) {
						Console.WriteLine (ex.Message);
					}
				};
			}
		}

		private void initBlinkId ()
		{
			blinkId = BlinkID.Instance;
			blinkId.SetContext (Android.App.Application.Context);
			blinkId.SetLicenseKey (LICENSE_KEY);
			blinkId.SetResultListener (new CustomResultListener (this));

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

			// Barcode recognizers
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
	

		private class CustomResultListener : BlinkIdResultListener 
		{
			Context context;

			public CustomResultListener (Context context) 
			{
				this.context = context;
			}

			#region implemented abstract members of BlinkIdResultListener
			public override void OnResultsAvailable (IList<IDictionary<string, string>> results)
			{
				// Check if results exist
				if (results == null) {
					Toast.MakeText (context, "Nothing scanned.", ToastLength.Long).Show ();
					return;
				}

				string message = "";
				string resultType = "";

				// Parse results from OCR
				foreach (var result in results) {
					if (result.TryGetValue ("ResultType", out resultType)) {
						message += resultType;

						foreach (KeyValuePair<string, string> resMap in result) {
							message += resMap.Key + ":" + resMap.Value + "\n";
						}
					}
				}


				// Set message if results are empty
				if (message == "") {
					message = "Results are empty!";
				}

				((Activity)context).RunOnUiThread(() => {
					AlertDialog.Builder alert = new AlertDialog.Builder (context);
					alert.SetTitle ("BlinkID Results");
					alert.SetPositiveButton ("OK", (senderAlert, args) => { });
					alert.SetMessage (message);
					alert.Show ();
				});
			
			}

			public override void OnDocumentImageAvailable (Bitmap document)
			{
				((Activity)context).RunOnUiThread (() => {
					ImageView documentImageView = ((Activity)context).FindViewById<ImageView> (Resource.Id.documentImageView);

					documentImageView.SetImageBitmap (document);
				});
			}
			#endregion
		}
	}
}


