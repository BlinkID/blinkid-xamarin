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

		// -(void)addAusIDBackRecognizer;
		[Export ("addAusIDBackRecognizer")]
		void AddAusIDBackRecognizer ();

		// -(void)addAusIDFrontRecognizer;
		[Export ("addAusIDFrontRecognizer")]
		void AddAusIDFrontRecognizer ();

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

		// -(void)addGerMrzRecognizer;
		[Export ("addGerMrzRecognizer")]
		void AddGerMrzRecognizer ();

		// -(void)addGerIDFrontRecognizer;
		[Export ("addGerIDFrontRecognizer")]
		void AddGerIDFrontRecognizer ();

		// -(void)addMrtdRecognizer;
		[Export ("addMrtdRecognizer")]
		void AddMrtdRecognizer ();

		// -(void)addMyKadRecognizer;
		[Export ("addMyKadRecognizer")]
		void AddMyKadRecognizer ();

		// -(void)addIKadRecognizer;
		[Export ("addIKadRecognizer")]
		void AddIKadRecognizer ();

		// -(void)addPdf417Recognizer;
		[Export ("addPdf417Recognizer")]
		void AddPdf417Recognizer ();

		// -(void)addSerbIDBackRecognizer;
		[Export ("addSerbIDBackRecognizer")]
		void AddSerbIDBackRecognizer ();

		// -(void)addSerbIDFrontRecognizer;
		[Export ("addSerbIDFrontRecognizer")]
		void AddSerbIDFrontRecognizer ();

		// -(void)addSlovakIDFrontRecognizer;
		[Export ("addSlovakIDFrontRecognizer")]
		void AddSlovakIDFrontRecognizer ();

		// -(void)addSlovakIDBackRecognizer;
		[Export ("addSlovakIDBackRecognizer")]
		void AddSlovakIDBackRecognizer ();

		// -(void)addSlovenianIDBackRecognizer;
		[Export ("addSlovenianIDBackRecognizer")]
		void AddSlovenianIDBackRecognizer ();

		// -(void)addSlovenianIDFrontRecognizer;
		[Export ("addSlovenianIDFrontRecognizer")]
		void AddSlovenianIDFrontRecognizer ();

		// -(void)addSingaporeIDBackRecognizer;
		[Export ("addSingaporeIDBackRecognizer")]
		void AddSingaporeIDBackRecognizer ();

		// -(void)addSingaporeIDFrontRecognizer;
		[Export ("addSingaporeIDFrontRecognizer")]
		void AddSingaporeIDFrontRecognizer ();

		// -(void)addUsdlRecognizer;
		[Export ("addUsdlRecognizer")]
		void AddUsdlRecognizer ();

		// -(void)addAusdlRecognizer;
		[Export ("addAusdlRecognizer")]
		void AddAusdlRecognizer ();

		// -(void)addUkdlRecognizer;
		[Export ("addUkdlRecognizer")]
		void AddUkdlRecognizer ();

		// -(void)addDedlRecognizer;
		[Export ("addDedlRecognizer")]
		void AddDedlRecognizer ();

		// -(void)addZXingRecognizer;
		[Export ("addZXingRecognizer")]
		void AddZXingRecognizer ();

		// -(void)addRawParser:(NSString *)identifier;
		[Export ("addRawParser:")]
		void AddRawParser (string identifier);

		// -(void)addAmountParser:(NSString *)identifier;
		[Export ("addAmountParser:")]
		void AddAmountParser (string identifier);

		// -(void)addDateParser:(NSString *)identifier;
		[Export ("addDateParser:")]
		void AddDateParser (string identifier);

		// -(void)addEmailParser:(NSString *)identifier;
		[Export ("addEmailParser:")]
		void AddEmailParser (string identifier);

		// -(void)addIbanParser:(NSString *)identifier;
		[Export ("addIbanParser:")]
		void AddIbanParser (string identifier);

		// -(void)addVinParser:(NSString *)identifierd;
		[Export ("addVinParser:")]
		void AddVinParser (string identifierd);

		// -(void)addLicensePlatesParser:(NSString *)identifier;
		[Export ("addLicensePlatesParser:")]
		void AddLicensePlatesParser (string identifier);

		// -(void)addTopUpOcrParser:(NSString *)identifier;
		[Export ("addTopUpOcrParser:")]
		void AddTopUpOcrParser (string identifier);

		// -(void)addRegexParser:(NSString *)regex identifier:(NSString *)identifier;
		[Export ("addRegexParser:identifier:")]
		void AddRegexParser (string regex, string identifier);

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