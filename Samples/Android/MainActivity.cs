using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using Com.Microblink.Wrapper.Xamarin;
using System.Collections.Generic;
using Android.Content;

namespace Android
{
	[Activity (Label = "BlinkID Xamarin", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		public const int MY_BLINKID_REQUEST_CODE = 0x101;

		public const string LICENSE_KEY = "4D6OMWCN-ZV6UR4II-LHEIGQPX-Y34SOZM5-2N437VUH-F7QX4XUH-F7QX4XUH-E4M2263V";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			RequestedOrientation = ScreenOrientation.Portrait;

			Button button = FindViewById<Button> (Resource.Id.startScanningButton);

			button.Click += delegate {
				BlinkID blinkId = BlinkID.Instance;
				blinkId.SetContext(this);
				blinkId.SetLicenseKey(LICENSE_KEY);
				blinkId.SetResultListener(new MResultListener(this));
				blinkId.Scan();
			};
		}
	

		private class MResultListener : BlinkIdResultListener 
		{
			Context context;

			public MResultListener (Context context) 
			{
				this.context = context;	
			}

			#region implemented abstract members of BlinkIdResultListener
			public override void OnResultsAvailable (IList<IDictionary<string, string>> results)
			{
				AlertDialog.Builder alert = new AlertDialog.Builder (this.context);

				alert.SetTitle ("BlinkID Results");

				alert.SetPositiveButton ("OK", (senderAlert, args) => {
					
				} );

				if (results [0] != null) {
					string message = "";

					foreach (var item in results[0]) {
						if (item.Key == "SecondaryId" || item.Key == "PrimaryId") {
							message += item.Value + " ";
						}
					}

					alert.SetMessage (message);
				} else {
					alert.SetMessage ("Error!");
				}

				alert.Show ();
			}
			#endregion
		}
	}
}


