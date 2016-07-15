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
		public const string LICENSE_KEY = "DLTBUL2B-FHCPH6CP-ETCJSTRC-6P4A6DF5-5NZZTNX5-EV7HWRXD-72M3N7JE-YHNITZGA";

		BlinkID blinkId;
		BlinkIdScanSettings blinkIdScanSettings;

		public BlinkIDImplementation ()
		{
			// Configure BlinkID
			blinkId = BlinkID.Instance;
			blinkId.SetContext(Android.App.Application.Context);
			blinkId.SetLicenseKey(LICENSE_KEY);
			blinkId.SetResultListener(new MResultListener());

			// Init settings
			blinkIdScanSettings = new BlinkIdScanSettings (Android.App.Application.Context, BlinkIdScanSettings.DeviceCameraType.CameraBackface);

			blinkIdScanSettings.SetAllowMultipleScanResultsOnSingleImage (false);

			// Define recognizers
			if (!blinkIdScanSettings.AddRecognizerMRTD ()) {
				Debug.WriteLine ("RecognizerMRTD is not supported on current device and camera settings");
			}
			//if (!blinkIdScanSettings.AddRecognizerUSDL ()) {
			//	Debug.WriteLine ("RecognizerUSDL is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerUKDL ()) {
			//	Debug.WriteLine ("RecognizerUKDL is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerDEDL ()) {
			//	Debug.WriteLine ("RecognizerDEDL is not supported");
			//}
			//// NOTE: If you use UKDL and DEDL at the same time than it will fallback to EUDL and it will be same as
			//if (!blinkIdScanSettings.AddRecognizerEUDL ()) {
			//	Debug.WriteLine ("RecognizerEUDL is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerSingaporeId ()) {
			//	Debug.WriteLine ("RecognizerSingaporeId is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerMyKad ()) {
			//	Debug.WriteLine ("RecognizerMyKad is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCroatianIdFront ()) {
			//	Debug.WriteLine ("RecognizerCroatianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCroatianIdBack ()) {
			//	Debug.WriteLine ("RecognizerCroatianIdBack is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerAustrianIdFront ()) {
			//	Debug.WriteLine ("RecognizerAustrianIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerAustrianIdBack ()) {
			//	Debug.WriteLine ("RecognizerAustrianIdBack is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCzechIdFront ()) {
			//	Debug.WriteLine ("RecognizerCzechIdFront is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerCzechIdBack ()) {
			//	Debug.WriteLine ("RecognizerCzechIdBack is not supported");
			//}

			//if (!blinkIdScanSettings.AddRecognizerPdf417 ()) {
			//	Debug.WriteLine ("RecognizerPdf417 is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerBarDecoder ()) {
			//	Debug.WriteLine ("RecognizerBarDecoder is not supported");
			//}
			//if (!blinkIdScanSettings.AddRecognizerZxing ()) {
			//	Debug.WriteLine ("RecognizerZxing is not supported");
			//}

			//if (!blinkIdScanSettings.AddParserAmount ("", true)) {
			//	Debug.WriteLine ("ParserAmount is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserDate ("", true)) {
			//	Debug.WriteLine ("ParserDate is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserEmail ("", true)) {
			//	Debug.WriteLine ("ParserEmail is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserIBAN ("", true)) {
			//	Debug.WriteLine ("ParserIBAN is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserRaw ("", true)) {
			//	Debug.WriteLine ("ParserRaw is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserRegex ("", "", true)) {
			//	Debug.WriteLine ("ParserRegex is not supported");
			//}
			//if (!blinkIdScanSettings.AddParserVIN ("", true)) {
			//	Debug.WriteLine ("ParserVIN is not supported");
			//}

			//if (!blinkIdScanSettings.AddDetectorIdCard ()) {
			//	Debug.WriteLine ("DetectorIdCard is not supported");
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

