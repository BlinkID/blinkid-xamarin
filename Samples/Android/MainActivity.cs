using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using Com.Microblink.Wrapper.Xamarin;
using System.Collections.Generic;
using Android.Content;
using System.Collections.ObjectModel;

namespace Android
{
	[Activity (Label = "BlinkID Xamarin", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		public const string LICENSE_KEY = "4D6OMWCN-ZV6UR4II-LHEIGQPX-Y34SOZM5-2N437VUH-F7QX4XUH-F7QX4XUH-E4M2263V";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			RequestedOrientation = ScreenOrientation.Portrait;

			Button button = FindViewById<Button> (Resource.Id.startScanningButton);

			if (!BlinkID.Instance.IsBlinkIDSupportedOnDevice (this)) {
				button.Enabled = false;
				Toast.MakeText (this, "BlinkID is not supported!", ToastLength.Long).Show ();
			} else {
				button.Click += delegate {
					BlinkID blinkId = BlinkID.Instance;
					blinkId.SetContext(Android.App.Application.Context);
					blinkId.SetLicenseKey(LICENSE_KEY);
					blinkId.SetResultListener(new CustomResultListener(this));

					ICollection<BlinkID.RecognizerType> recognizers = new Collection<BlinkID.RecognizerType>();

					// recognize machine-readable travel document
					recognizers.Add(BlinkID.RecognizerType.Mrtd);

					// recognize US Driver's Licenses
					// recognizers.Add(BlinkID.RecognizerType.Usdl);

					// recognize UK Driver's Licenses
					// recognizers.Add(BlinkID.RecognizerType.Ukdl);

					// recognize German Driver's Licenses
					// recognizers.Add(BlinkID.RecognizerType.Dedl);

					// recognize Malaysian ID documents
					// recognizers.Add(BlinkID.RecognizerType.Mykad);

					// recognize 1D barcodes that uses BlinkID's implementation of scanning algorithms
					// recognizers.Add(BlinkID.RecognizerType.Bardecoder);

					// recognize barcodes that use ZXing's implementation of scanning algorithms
					// recognizers.Add(BlinkID.RecognizerType.Zxing);

					// recognize PDF417
					// recognizers.Add(BlinkID.RecognizerType.Pdf417);

					bool useFrontCamera = false;
					recognizers = BlinkID.Instance.FilterOutUnsupportedRecognizers(recognizers, useFrontCamera);
					blinkId.Scan(recognizers, useFrontCamera);
				};
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
						if (resultType == "MRTD") {
							foreach (KeyValuePair<string, string> resMap in result) {
								message += resMap.Key + ":" + resMap.Value + "\n";
							}
						}
					}
				}

				// Set message if results are empty
				if (message == "") {
					message = "Results are empty!";
				} 

				AlertDialog.Builder alert = new AlertDialog.Builder (context);
				alert.SetTitle ("BlinkID Results");
				alert.SetPositiveButton ("OK", (senderAlert, args) => {});
				alert.SetMessage (message);
				alert.Show ();
			}
			#endregion
		}
	}
}


