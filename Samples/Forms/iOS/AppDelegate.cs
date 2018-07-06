using Foundation;
using UIKit;

namespace BlinkIDFormsSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

            Xamarin.Forms.DependencyService.Register<Microblink.Forms.iOS.MicroblinkScannerFactoryImplementation>();

			LoadApplication (new BlinkIDApp.App());

			return base.FinishedLaunching (app, options);
		}
	}
}

