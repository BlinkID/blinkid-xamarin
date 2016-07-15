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
	[Activity (Label = "BlinkID Xamarin", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		public const string LICENSE_KEY = "6XLKZUNU-YVHGTCUI-VNIHBRKN-ZNOY4TT7-CBPIOL7B-PZPIOL7B-PZPIPLYH-76ENZW4P";
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

			// Define recognizers
			//if (!blinkIdScanSettings.AddRecognizerMRTD ()) {
			//	Console.WriteLine ("RecognizerMRTD is not supported on current device and camera settings");
			//}
			//if (!blinkIdScanSettings.AddRecognizerUSDL ()) {
			//	Console.WriteLine ("RecognizerUSDL is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerUKDL ()) {
			//	Console.WriteLine ("RecognizerUKDL is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerDEDL ()) {
			//	Console.WriteLine ("RecognizerDEDL is not supported");
			//}
			//// NOTE: If you use UKDL and DEDL at the same time than it will fallback to EUDL and it will be same as
			//if (!blinkIdScanSettings.AddRecognizerEUDL ()) {
			//	Console.WriteLine ("RecognizerEUDL is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerSingaporeId ()) {
			//	Console.WriteLine ("RecognizerSingaporeId is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerMyKad ()) {
			//	Console.WriteLine ("RecognizerMyKad is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCroatianIdFront ()) {
			//	Console.WriteLine ("RecognizerCroatianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCroatianIdBack ()) {
			//	Console.WriteLine ("RecognizerCroatianIdBack is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerAustrianIdFront ()) {
			//	Console.WriteLine ("RecognizerAustrianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerAustrianIdBack ()) {
			//	Console.WriteLine ("RecognizerAustrianIdBack is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCzechIdFront ()) {
			//	Console.WriteLine ("RecognizerCzechIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCzechIdBack ()) {
			//	Console.WriteLine ("RecognizerCzechIdBack is not supported");
			//}

			//if (!blinkIdScanSettings.AddRecognizerPdf417 ()) {
			//	Console.WriteLine ("RecognizerPdf417 is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerBarDecoder ()) {
			//	Console.WriteLine ("RecognizerBarDecoder is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerZxing ()) {
			//	Console.WriteLine ("RecognizerZxing is not supported");
			//}

			//if (!blinkIdScanSettings.AddParserAmount ("", true)) {
			//	Console.WriteLine ("ParserAmount is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserDate ("", true)) {
			//	Console.WriteLine ("ParserDate is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserEmail ("", true)) {
			//	Console.WriteLine ("ParserEmail is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserIBAN ("IBAN", true)) {
			//	Console.WriteLine ("ParserIBAN is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserRaw ("", true)) {
			//	Console.WriteLine ("ParserRaw is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserRegex ("", "", true)) {
			//	Console.WriteLine ("ParserRegex is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserVIN ("", true)) {
			//	Console.WriteLine ("ParserVIN is not supported");
			//}

			if (!blinkIdScanSettings.AddDetectorIdCard ()) {
				Console.WriteLine ("DetectorIdCard is not supported");
			}
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


