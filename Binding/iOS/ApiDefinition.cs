using Foundation;
using ObjCRuntime;
using UIKit;

namespace MicroBlink {
	// @interface BlinkID : NSObject
	[BaseType (typeof(NSObject))]
	interface BlinkID
	{
		[Wrap ("WeakDelegate")]
		BlinkIDDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BlinkIDDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic) NSString * licenseKey;
		[Export ("licenseKey")]
		string LicenseKey { get; set; }

		// +(instancetype)instance;
		[Static]
		[Export ("instance")]
		BlinkID Instance ();

		// -(void)addAusIDBackRecognizerSettings;
		[Export ("addAusIDBackRecognizerSettings")]
		void AddAusIDBackRecognizerSettings ();

		// -(void)addAusIDFrontRecognizerSettings;
		[Export ("addAusIDFrontRecognizerSettings")]
		void AddAusIDFrontRecognizerSettings ();

		// -(void)addBarDecoderRecognizer;
		[Export ("addBarDecoderRecognizer")]
		void AddBarDecoderRecognizer ();

		// -(void)addCroIdBackRecognizer;
		[Export ("addCroIdBackRecognizer")]
		void AddCroIdBackRecognizer ();

		// -(void)addCroIdFrontRecognizer;
		[Export ("addCroIdFrontRecognizer")]
		void AddCroIdFrontRecognizer ();

		// -(void)addCzIDBackRecognizer;
		[Export ("addCzIDBackRecognizer")]
		void AddCzIDBackRecognizer ();

		// -(void)addCzIDFrontRecognizer;
		[Export ("addCzIDFrontRecognizer")]
		void AddCzIDFrontRecognizer ();

		// -(void)addEudlRecognizer;
		[Export ("addEudlRecognizer")]
		void AddEudlRecognizer ();

		// -(void)addMrtdRecognizer;
		[Export ("addMrtdRecognizer")]
		void AddMrtdRecognizer ();

		// -(void)addMyKadRecognizer;
		[Export ("addMyKadRecognizer")]
		void AddMyKadRecognizer ();

		// -(void)addPdf417Recognizer;
		[Export ("addPdf417Recognizer")]
		void AddPdf417Recognizer ();

		// -(void)addSingaporeIDRecognizerSettings;
		[Export ("addSingaporeIDRecognizerSettings")]
		void AddSingaporeIDRecognizerSettings ();

		// -(void)addUsdlRecognizer;
		[Export ("addUsdlRecognizer")]
		void AddUsdlRecognizer ();

		// -(void)addUkdlRecognizer;
		[Export ("addUkdlRecognizer")]
		void AddUkdlRecognizer ();

		// -(void)addDedlRecognizer;
		[Export ("addDedlRecognizer")]
		void AddDedlRecognizer ();

		// -(void)addZXingRecognizer;
		[Export ("addZXingRecognizer")]
		void AddZXingRecognizer ();

		// -(void)addRawParser:(NSString *)id;
		[Export ("addRawParser:")]
		void AddRawParser (string id);

		// -(void)addAmountParser:(NSString *)id;
		[Export ("addAmountParser:")]
		void AddAmountParser (string id);

		// -(void)addDateParser:(NSString *)id;
		[Export ("addDateParser:")]
		void AddDateParser (string id);

		// -(void)addEmailParser:(NSString *)id;
		[Export ("addEmailParser:")]
		void AddEmailParser (string id);

		// -(void)addIbanParser:(NSString *)id;
		[Export ("addIbanParser:")]
		void AddIbanParser (string id);

		// -(void)addVinParser:(NSString *)id;
		[Export ("addVinParser:")]
		void AddVinParser (string id);

		// -(void)addRegexParser:(NSString *)regex id:(NSString *)id;
		[Export ("addRegexParser:id:")]
		void AddRegexParser (string regex, string id);

		// -(void)addIdCardDetector;
		[Export ("addIdCardDetector")]
		void AddIdCardDetector ();

		// -(void)clearAllRecognizers;
		[Export ("clearAllRecognizers")]
		void ClearAllRecognizers ();

		// -(void)clearAllParsers;
		[Export ("clearAllParsers")]
		void ClearAllParsers ();

		// -(void)clearAllDetectors;
		[Export ("clearAllDetectors")]
		void ClearAllDetectors ();

		// -(void)scan:(BOOL)isFrontCamera;
		[Export ("scan:")]
		void Scan (bool isFrontCamera);
	}

	// @protocol BlinkIDDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BlinkIDDelegate
	{
		// @required -(void)blinkID:(BlinkID *)blinkid didOutputResults:(NSArray<NSDictionary *> *)results;
		[Abstract]
		[Export ("blinkID:didOutputResults:")]
		void DidOutputResults (BlinkID blinkid, NSDictionary [] results);

		// @required -(void)blinkID:(BlinkID *)blinkid didOutputImage:(UIImage *)image name:(NSString *)name;
		[Abstract]
		[Export ("blinkID:didOutputImage:name:")]
		void DidOutputImage (BlinkID blinkid, UIImage image, string name);
	}
}