using Foundation;
using ObjCRuntime;

namespace MicroBlink {
	// @interface BlinkID : NSObject
	[BaseType (typeof(NSObject))]
	interface BlinkID
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		BlinkIDDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BlinkIDDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) NSString * licenseKey;
		[Export ("licenseKey", ArgumentSemantic.Strong)]
		string LicenseKey { get; set; }

		// +(instancetype)instance;
		[Static]
		[Export ("instance")]
		BlinkID Instance ();

		// -(void)scan;
		[Export ("scan")]
		void Scan ();
	}

	// @protocol BlinkIDDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BlinkIDDelegate
	{
		// @required -(void)blinkID:(BlinkID *)blinkid didOutputResults:(NSArray<NSDictionary *> *)results;
		[Abstract]
		[Export ("blinkID:didOutputResults:")]
		void DidOutputResults (BlinkID blinkid, NSDictionary[] results);
	}
}