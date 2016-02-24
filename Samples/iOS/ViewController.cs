using System;

using UIKit;
using Foundation;
using System.Diagnostics;

using MicroBlink;

namespace iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			CustomDelegate customDelegate = new CustomDelegate ();

			BlinkID.Instance().LicenseKey = "CPXEWTU6-23VZUKIW-PKZ3JZMC-ZJZJJF7N-76T7VLXP-MOPXWCKG-FJNIDWKE-VBBUL3FU";
			BlinkID.Instance().Delegate = customDelegate;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void StartScanningButton_TouchUpInside (UIButton sender)
		{
			BlinkID.Instance().Scan();
		}

		class CustomDelegate : BlinkIDDelegate
		{
			#region implemented abstract members of BlinkIDDelegate

			public override void DidOutputResults (BlinkID blinkid, NSDictionary[] results)
			{
				UIAlertView alert = new UIAlertView () { 
					Title = "BlinkID results", Message = results[0].ToString()
				};
				alert.AddButton("OK");
				alert.Show ();
			}

			#endregion
		}
	}
}

