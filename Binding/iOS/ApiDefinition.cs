using Foundation;
using ObjCRuntime;
using UIKit;

namespace MicroBlink {
	// @interface BlinkID : NSObject
	[BaseType (typeof(NSObject))]
	interface BlinkID
	{
        [Wrap("WeakDelegate")]
        BlinkIDDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BlinkIDDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) NSString * licenseKey;
        [Export("licenseKey")]
        string LicenseKey { get; set; }

        // +(instancetype)instance;
        [Static]
        [Export("instance")]
        BlinkID Instance();

        // -(void)addAusIDBackRecognizer;
        [Export("addAusIDBackRecognizer")]
        void AddAusIDBackRecognizer();

        // -(void)addAusIDFrontRecognizer;
        [Export("addAusIDFrontRecognizer")]
        void AddAusIDFrontRecognizer();

        // -(void)addAusPassportRecognizer;
        [Export("addAusPassportRecognizer")]
        void AddAusPassportRecognizer();

        // -(void)addAusIDCombinedRecognizer;
        [Export("addAusIDCombinedRecognizer")]
        void AddAusIDCombinedRecognizer();

        // -(void)addAustraliaDLBackRecognizer;
        [Export("addAustraliaDLBackRecognizer")]
        void AddAustraliaDLBackRecognizer();

        // -(void)addAustraliaDLFrontRecognizer;
        [Export("addAustraliaDLFrontRecognizer")]
        void AddAustraliaDLFrontRecognizer();

        // -(void)addBarDecoderRecognizer;
        [Export("addBarDecoderRecognizer")]
        void AddBarDecoderRecognizer();

        // -(void)addBarcodeRecognizer;
        [Export("addBarcodeRecognizer")]
        void AddBarcodeRecognizer();

        // -(void)addCroIdBackRecognizer;
        [Export("addCroIdBackRecognizer")]
        void AddCroIdBackRecognizer();

        // -(void)addCroIdFrontRecognizer;
        [Export("addCroIdFrontRecognizer")]
        void AddCroIdFrontRecognizer();

        // -(void)addCroCombinedRecognizer;
        [Export("addCroCombinedRecognizer")]
        void AddCroCombinedRecognizer();

        // -(void)addCzIDBackRecognizer;
        [Export("addCzIDBackRecognizer")]
        void AddCzIDBackRecognizer();

        // -(void)addCzIDFrontRecognizer;
        [Export("addCzIDFrontRecognizer")]
        void AddCzIDFrontRecognizer();

        // -(void)addCzCombinedRecognizer;
        [Export("addCzCombinedRecognizer")]
        void AddCzCombinedRecognizer();

        // -(void)addEudlRecognizer;
        [Export("addEudlRecognizer")]
        void AddEudlRecognizer();

        // -(void)addGerIDFrontRecognizer;
        [Export("addGerIDFrontRecognizer")]
        void AddGerIDFrontRecognizer();

        // -(void)addGerIDBackRecognizer;
        [Export("addGerIDBackRecognizer")]
        void AddGerIDBackRecognizer();

        // -(void)addGerIDOldRecognizer;
        [Export("addGerIDOldRecognizer")]
        void AddGerIDOldRecognizer();

        // -(void)addGerPassportRecognizer;
        [Export("addGerPassportRecognizer")]
        void AddGerPassportRecognizer();

        // -(void)addGerCombinedRecognizer;
        [Export("addGerCombinedRecognizer")]
        void AddGerCombinedRecognizer();

        // -(void)addMrtdRecognizer;
        [Export("addMrtdRecognizer")]
        void AddMrtdRecognizer();

        // -(void)addMyKadRecognizer;
        [Export("addMyKadRecognizer")]
        void AddMyKadRecognizer();

        // -(void)addMyTenteraRecognizer;
        [Export("addMyTenteraRecognizer")]
        void AddMyTenteraRecognizer();

        // -(void)addIKadRecognizer;
        [Export("addIKadRecognizer")]
        void AddIKadRecognizer();

        // -(void)addIndonesianIDFrontRecognizer;
        [Export("addIndonesianIDFrontRecognizer")]
        void AddIndonesianIDFrontRecognizer();

        // -(void)addPdf417Recognizer;
        [Export("addPdf417Recognizer")]
        void AddPdf417Recognizer();

        // -(void)addPolishIDBackRecognizer;
        [Export("addPolishIDBackRecognizer")]
        void AddPolishIDBackRecognizer();

        // -(void)addPolishIDFrontRecognizer;
        [Export("addPolishIDFrontRecognizer")]
        void AddPolishIDFrontRecognizer();

        // -(void)addPolishIDCombinedRecognizer;
        [Export("addPolishIDCombinedRecognizer")]
        void AddPolishIDCombinedRecognizer();

        // -(void)addSerbIDBackRecognizer;
        [Export("addSerbIDBackRecognizer")]
        void AddSerbIDBackRecognizer();

        // -(void)addSerbIDFrontRecognizer;
        [Export("addSerbIDFrontRecognizer")]
        void AddSerbIDFrontRecognizer();

        // -(void)addSerbIDCombinedRecognizer;
        [Export("addSerbIDCombinedRecognizer")]
        void AddSerbIDCombinedRecognizer();

        // -(void)addSlovakIDFrontRecognizer;
        [Export("addSlovakIDFrontRecognizer")]
        void AddSlovakIDFrontRecognizer();

        // -(void)addSlovakIDBackRecognizer;
        [Export("addSlovakIDBackRecognizer")]
        void AddSlovakIDBackRecognizer();

        // -(void)addSlovakCombinedRecognizer;
        [Export("addSlovakCombinedRecognizer")]
        void AddSlovakCombinedRecognizer();

        // -(void)addSlovenianIDBackRecognizer;
        [Export("addSlovenianIDBackRecognizer")]
        void AddSlovenianIDBackRecognizer();

        // -(void)addSlovenianIDFrontRecognizer;
        [Export("addSlovenianIDFrontRecognizer")]
        void AddSlovenianIDFrontRecognizer();

        // -(void)addSlovenianCombinedRecognizer;
        [Export("addSlovenianCombinedRecognizer")]
        void AddSlovenianCombinedRecognizer();

        // -(void)addSingaporeIDBackRecognizer;
        [Export("addSingaporeIDBackRecognizer")]
        void AddSingaporeIDBackRecognizer();

        // -(void)addSingaporeIDFrontRecognizer;
        [Export("addSingaporeIDFrontRecognizer")]
        void AddSingaporeIDFrontRecognizer();

        // -(void)addSingaporeCombinedRecognizer;
        [Export("addSingaporeCombinedRecognizer")]
        void AddSingaporeCombinedRecognizer();

        // -(void)addSwissIDFrontRecognizer;
        [Export("addSwissIDFrontRecognizer")]
        void AddSwissIDFrontRecognizer();

        // -(void)addSwissIDBackRecognizer;
        [Export("addSwissIDBackRecognizer")]
        void AddSwissIDBackRecognizer();

        // -(void)addSwissPassportRecognizer;
        [Export("addSwissPassportRecognizer")]
        void AddSwissPassportRecognizer();

        // -(void)addUsdlRecognizer;
        [Export("addUsdlRecognizer")]
        void AddUsdlRecognizer();

        // -(void)addAusdlRecognizer;
        [Export("addAusdlRecognizer")]
        void AddAusdlRecognizer();

        // -(void)addUkdlRecognizer;
        [Export("addUkdlRecognizer")]
        void AddUkdlRecognizer();

        // -(void)addDedlRecognizer;
        [Export("addDedlRecognizer")]
        void AddDedlRecognizer();

        // -(void)addZXingRecognizer;
        [Export("addZXingRecognizer")]
        void AddZXingRecognizer();

        // -(void)addVinRecognizer;
        [Export("addVinRecognizer")]
        void AddVinRecognizer();

        // -(void)addMrtdCombinedRecognizer;
        [Export("addMrtdCombinedRecognizer")]
        void AddMrtdCombinedRecognizer();

        // -(void)addRawParser:(NSString *)identifier;
        [Export("addRawParser:")]
        void AddRawParser(string identifier);

        // -(void)addAmountParser:(NSString *)identifier;
        [Export("addAmountParser:")]
        void AddAmountParser(string identifier);

        // -(void)addDateParser:(NSString *)identifier;
        [Export("addDateParser:")]
        void AddDateParser(string identifier);

        // -(void)addEmailParser:(NSString *)identifier;
        [Export("addEmailParser:")]
        void AddEmailParser(string identifier);

        // -(void)addIbanParser:(NSString *)identifier;
        [Export("addIbanParser:")]
        void AddIbanParser(string identifier);

        // -(void)addVinParser:(NSString *)identifierd;
        [Export("addVinParser:")]
        void AddVinParser(string identifierd);

        // -(void)addLicensePlatesParser:(NSString *)identifier;
        [Export("addLicensePlatesParser:")]
        void AddLicensePlatesParser(string identifier);

        // -(void)addTopUpOcrParser:(NSString *)identifier;
        [Export("addTopUpOcrParser:")]
        void AddTopUpOcrParser(string identifier);

        // -(void)addRegexParser:(NSString *)regex identifier:(NSString *)identifier;
        [Export("addRegexParser:identifier:")]
        void AddRegexParser(string regex, string identifier);

        // -(void)addIdCardDetector;
        [Export("addIdCardDetector")]
        void AddIdCardDetector();

        // -(void)clearAllRecognizers;
        [Export("clearAllRecognizers")]
        void ClearAllRecognizers();

        // -(void)clearAllParsers;
        [Export("clearAllParsers")]
        void ClearAllParsers();

        // -(void)clearAllDetectors;
        [Export("clearAllDetectors")]
        void ClearAllDetectors();

        // -(void)scan:(BOOL)isFrontCamera;
        [Export("scan:")]
        void Scan(bool isFrontCamera);
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