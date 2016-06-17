using System;
using BlinkIDApp;
using BlinkIDApp.Droid;
using Com.Microblink.Wrapper.Xamarin;
using System.Collections.Generic;
using Android.Content;
using Xamarin.Forms;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency (typeof (BlinkIDImplementation))]
namespace BlinkIDApp.Droid
{
	public class BlinkIDImplementation : IBlinkID
	{
		public const string LICENSE_KEY = "DLTBUL2B-FHCPH6CP-ETCJSTRC-6P4A6DF5-5NZZTNX5-EV7HWRXD-72M3N7JE-YHNITZGA";

		BlinkID blinkId;
		bool useFrontCamera;
		List<BlinkID.RecognizerType> recognizers;

		public BlinkIDImplementation ()
		{
			// Configure BlinkID
			blinkId = BlinkID.Instance;
			blinkId.SetContext(Android.App.Application.Context);
			blinkId.SetLicenseKey(LICENSE_KEY);
			blinkId.SetResultListener(new MResultListener());

			// Define recognizers
			recognizers = new List<BlinkID.RecognizerType>();
			recognizers.Add(BlinkID.RecognizerType.Mrtd);
			recognizers.Add(BlinkID.RecognizerType.Ukdl);

			// Use front camera for OCR true/false
			useFrontCamera = false;
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
			#endregion
		}

		#region IBlinkID implementation

		public void Scan ()
		{
			Debug.WriteLine ("Native Scan is started");
			blinkId.Scan(recognizers, useFrontCamera);
		}

		#endregion
	}
}

