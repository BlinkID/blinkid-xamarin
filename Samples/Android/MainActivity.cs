using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using Com.Microblink.Wrapper.Xamarin;

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

			// check if BlinkID is supported on the device
//			RequestedCompatibilityStatus supportStatus = RecognizerCompatibility.

//			Com.Microblink.Util.RecognizerCompatibilityStatus supportStatus = Com.Microblink.Util.RecognizerCompatibilityStatus.


//			RecognizerCompatibilityStatus supportStatus = RecognizerCompatibility.


//			Com.Microblink.Wrapper.Xamarin.


			// Get our button from the layout resource,
			// and attach an event to it

			Button button = FindViewById<Button> (Resource.Id.startScanningButton);

			button.Click += delegate {
				BlinkID blinkId = BlinkID.Instance;
				blinkId.SetContext(this);
				blinkId.SetLicenseKey(LICENSE_KEY);
				blinkId.SetResultListener(new MResultListener());
				blinkId.Scan();
			};

//			Com.Microblink.Wrapper.

//			Resource.Layout.

//			Resource.Layout.
		}
	

		private class MResultListener : BlinkIdResultListener 
		{
			#region implemented abstract members of BlinkIdResultListener
			public override void OnResultsAvailable (System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, string>> p0)
			{
				throw new System.NotImplementedException ();
			}
			#endregion
		}
	}
}


