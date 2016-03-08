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
				blinkId.SetContext(Android.App.Application.Context);
				blinkId.SetLicenseKey(LICENSE_KEY);
				blinkId.SetResultListener(new MResultListener(this));

				List<BlinkID.RecognizerType> recognizers = new List<BlinkID.RecognizerType>();
				recognizers.Add(BlinkID.RecognizerType.Mrtd);
				recognizers.Add(BlinkID.RecognizerType.Ukdl);

				blinkId.Scan(recognizers, true);
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
				AlertDialog.Builder alert = new AlertDialog.Builder (context);

				alert.SetTitle ("BlinkID Results");

				alert.SetPositiveButton ("OK", (senderAlert, args) => {
					
				} );

				string message = "";

				foreach (var result in results) {
					message += string.Join (";", result);
				}

				if (message == "") {
					message = "Error!";
				} 

				alert.SetMessage (message);

				alert.Show ();
			}
			#endregion
		}
	}
}


