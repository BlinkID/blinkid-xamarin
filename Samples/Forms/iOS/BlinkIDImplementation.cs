using System;
using Foundation;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using BlinkIDApp.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency (typeof (BlinkIDImplementation))]
namespace BlinkIDApp.iOS
{
	public class BlinkIDImplementation : IBlinkID
	{
		public BlinkIDImplementation ()
		{
			CustomDelegate customDelegate = new CustomDelegate ();

			MicroBlink.BlinkID.Instance().LicenseKey = "7YV32QWG-VKEWRHTY-36HDZ6JL-PRMPFVN6-ED5OXMSY-6LK34IH2-5OZFR4WV-W2PE7JQL";
			MicroBlink.BlinkID.Instance().Delegate = customDelegate;
		}

		class CustomDelegate : MicroBlink.BlinkIDDelegate
		{
			#region implemented abstract members of BlinkIDDelegate

			public override void DidOutputResults (MicroBlink.BlinkID blinkid, NSDictionary[] results)
			{
				// Transform results from NSDictionary[] to List<Dictionary<string, string>>
				var transformedResults = new List<Dictionary<string, string>> ();

				foreach (var result in results) {
					var dict = new Dictionary<string, string> ();

					foreach (var item in result) {
						dict.Add (item.Key.ToString(), item.Value.ToString());
					}

					transformedResults.Add (dict);
				}

				// Send results to subscribers
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
			MicroBlink.BlinkID.Instance ().Scan ();
		}

		#endregion
	}
}

