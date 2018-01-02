//
//  BlinkID.m
//  MicroBlink
//
//  Created by Jura on 24/02/16.
//  Copyright © 2016 MicroBlink. All rights reserved.
//

#import "BlinkID.h"

#import <MicroBlink/MicroBlink.h>

@interface BlinkID () <PPScanningDelegate>

@property (nonatomic) PPCameraType cameraType;

@property (nonatomic) NSMutableArray<PPRecognizerSettings *> *recognizers;

@property (nonatomic) NSMutableArray<PPOcrParserFactory *> *parsers;

@property (nonatomic) NSMutableArray<PPDetectorSettings *> *detectors;

@property (nonatomic) NSMutableArray<NSString *> *parserNames;

@end

// result const key
static NSString* const kResultType = @"ResultType";


// recognizer MRTD result keys
static NSString* const kRaw = @"raw";
static NSString* const kMRTDDateOfBirth = @"DateOfBirth";
static NSString* const kMRTDDateOExpiry = @"DateOfExpiry";

@implementation BlinkID

- (instancetype)init {
    if (self = [super init]) {
        _recognizers = [NSMutableArray<PPRecognizerSettings *> array];
        _parsers = [NSMutableArray<PPOcrParserFactory *> array];
        _detectors = [NSMutableArray<PPDetectorSettings *> array];
        _parserNames = [NSMutableArray<NSString *> array];
    }
    return self;
}

+ (instancetype)instance {
    static BlinkID *sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[BlinkID alloc] init];
    });
    return sharedInstance;
}

- (void)scan:(BOOL)isFrontCamera {

    if (!isFrontCamera) {
        self.cameraType = PPCameraTypeBack;
    } else {
        self.cameraType = PPCameraTypeFront;
    }

    /** Instantiate the scanning coordinator */
    NSError *error;
    PPCameraCoordinator *coordinator = [self coordinatorWithError:&error];

    /** If scanning isn't supported, present an error */
    if (coordinator == nil) {
        NSString *messageString = [error localizedDescription];
        [[[UIAlertView alloc] initWithTitle:@"Warning"
                                    message:messageString
                                   delegate:nil
                          cancelButtonTitle:@"OK"
                          otherButtonTitles:nil, nil] show];

        return;
    }

    /** Allocate and present the scanning view controller */
    UIViewController<PPScanningViewController> *scanningViewController =
        [PPViewControllerFactory cameraViewControllerWithDelegate:self coordinator:coordinator error:nil];

    // allow rotation if VC is displayed as a modal view controller
    scanningViewController.autorotate = YES;
    scanningViewController.supportedOrientations = UIInterfaceOrientationMaskAll;

    UIViewController *rootViewController = [[[UIApplication sharedApplication] keyWindow] rootViewController];
    [rootViewController presentViewController:scanningViewController animated:YES completion:nil];
}

#pragma mark - PPScanDelegate

- (void)scanningViewControllerUnauthorizedCamera:(UIViewController<PPScanningViewController> *)scanningViewController {
    // Add any logic which handles UI when app user doesn't allow usage of the phone's camera
}

- (void)scanningViewController:(UIViewController<PPScanningViewController> *)scanningViewController didFindError:(NSError *)error {
    // Can be ignored. See description of the method
}

- (void)scanningViewControllerDidClose:(UIViewController<PPScanningViewController> *)scanningViewController {

    // As scanning view controller is presented full screen and modally, dismiss it
    [scanningViewController dismissViewControllerAnimated:YES completion:nil];
}

- (void)scanningViewController:(UIViewController<PPScanningViewController> *)scanningViewController
             didOutputMetadata:(PPMetadata *)metadata {

    if ([metadata isKindOfClass:[PPImageMetadata class]]) {
        PPImageMetadata *imageMetadata = (PPImageMetadata *)metadata;

        UIImage *image = [imageMetadata image];
        NSString *name = [imageMetadata name];

        NSLog(@"Will call didOutputImage");

        [self.delegate blinkID:self didOutputImage:image name:name];

        NSLog(@"Is called didOutputImage");
    }
}

- (void)scanningViewController:(UIViewController<PPScanningViewController> *)scanningViewController didOutputResults:(NSArray *)results {

    // Here you process scanning results. Scanning results are given in the array of PPRecognizerResult objects.

    // first, pause scanning until we process all the results
    [scanningViewController pauseScanning];

    NSMutableArray<NSDictionary *> *dictionaryResults = [[NSMutableArray alloc] init];

    for (id obj in results) {
        if ([obj isKindOfClass:[PPRecognizerResult class]]) {
            PPRecognizerResult *result = (PPRecognizerResult *)obj;

            NSMutableDictionary *dict = [[result getAllStringElements] mutableCopy];

            if ([result isKindOfClass:[PPMrtdRecognizerResult class]]) {
                PPMrtdRecognizerResult *mrtdDecoderResult = (PPMrtdRecognizerResult *)result;
                [self setDictionary:dict withMrtdRecognizerResult:mrtdDecoderResult];
            } else if ([result isKindOfClass:[PPUsdlRecognizerResult class]]) {
                [dict setObject:@"Usdl" forKey:kResultType];
            } else if ([result isKindOfClass:[PPEudlRecognizerResult class]]) {
                if (((PPEudlRecognizerResult *)result).country == PPEudlCountryUnitedKingdom) {
                    [dict setObject:@"Ukdl" forKey:kResultType];
                } else if (((PPEudlRecognizerResult *)result).country == PPEudlCountryGermany) {
                    [dict setObject:@"Dedl" forKey:kResultType];
                } else if (((PPEudlRecognizerResult *)result).country == PPEudlCountryAny) {
                    [dict setObject:@"Eudl" forKey:kResultType];
                }
            } else if ([result isKindOfClass:[PPMyKadFrontRecognizerResult class]]) {
                [dict setObject:@"MyKad" forKey:kResultType];
            } else if ([result isKindOfClass:[PPPdf417RecognizerResult class]]) {
                [dict setObject:@"Pdf417" forKey:kResultType];
            } else if ([result isKindOfClass:[PPBarDecoderRecognizerResult class]]) {
                [dict setObject:@"BarDecoder" forKey:kResultType];
            } else if ([result isKindOfClass:[PPBarcodeRecognizerResult class]]) {
                [dict setObject:@"Barcode" forKey:kResultType];
            } else if ([result isKindOfClass:[PPZXingRecognizerResult class]]) {
                [dict setObject:@"ZXing" forKey:kResultType];
            } else if ([result isKindOfClass:[PPAusIDBackRecognizerResult class]]) {
                [dict setObject:@"Austrian ID Back" forKey:kResultType];
            } else if ([result isKindOfClass:[PPAusIDFrontRecognizerResult class]]) {
                [dict setObject:@"Austrian ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPAusPassportRecognizerResult class]]) {
                [dict setObject:@"Austrian Passport" forKey:kResultType];
            } else if ([result isKindOfClass:[PPAusIDCombinedRecognizerResult class]]) {
                [dict setObject:@"Austrian Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPCroIDBackRecognizerResult class]]) {
                [dict setObject:@"Croatian ID Back" forKey:kResultType];
            } else if ([result isKindOfClass:[PPCroIDFrontRecognizerResult class]]) {
                [dict setObject:@"Croatian ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPCroIDCombinedRecognizerResult class]]) {
                [dict setObject:@"Croatian Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPCzIDBackRecognizerResult class]]) {
                [dict setObject:@"Czech ID Back" forKey:kResultType];
            } else if ([result isKindOfClass:[PPCzIDFrontRecognizerResult class]]) {
                [dict setObject:@"Czech ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPCzIDCombinedRecognizerResult class]]) {
                [dict setObject:@"Czech Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPGermanIDBackRecognizerResult class]]) {
                [dict setObject:@"German ID Back" forKey:kResultType];
            }  else if ([result isKindOfClass:[PPGermanIDFrontRecognizerResult class]]) {
                [dict setObject:@"German ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPGermanOldIDRecognizerResult class]]) {
                [dict setObject:@"German ID Old" forKey:kResultType];
            } else if ([result isKindOfClass:[PPGermanPassportRecognizerResult class]]) {
                [dict setObject:@"German Passport" forKey:kResultType];
            } else if ([result isKindOfClass:[PPGermanIDCombinedRecognizerResult class]]){
                [dict setObject:@"German Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSerbianIDBackRecognizerResult class]]) {
                [dict setObject:@"Serbian ID Back" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSerbianIDFrontRecognizerResult class]]) {
                [dict setObject:@"Serbian ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSerbianIDCombinedRecognizerResult class]]) {
                [dict setObject:@"Serbian Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSlovakIDBackRecognizerResult class]]) {
                [dict setObject:@"Slovak ID Back" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSlovakIDFrontRecognizerResult class]]) {
                [dict setObject:@"Slovak ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSlovakIDCombinedRecognizerResult class]]) {
                [dict setObject:@"Slovak Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSlovenianIDBackRecognizerResult class]]) {
                [dict setObject:@"Slovenian ID Back" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSlovenianIDFrontRecognizerResult class]]) {
                [dict setObject:@"Slovenian ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSlovenianIDCombinedRecognizerResult class]]) {
                [dict setObject:@"Slovenian Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSingaporeIDBackRecognizerResult class]]) {
                [dict setObject:@"Singapore ID Back" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSingaporeIDFrontRecognizerResult class]]) {
                [dict setObject:@"Singapore ID Front" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSingaporeIDCombinedRecognizerResult class]]) {
                [dict setObject:@"Singapore Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPSwissPassportRecognizerResult class]]) {
                [dict setObject:@"Swiss Passport" forKey:kResultType];
            } else if ([result isKindOfClass:[PPVinRecognizerResult class]]) {
                [dict setObject:@"VIN" forKey:kResultType];
            } else if ([result isKindOfClass:[PPMrtdCombinedRecognizerResult class]]) {
                [dict setObject:@"MRTD Combined" forKey:kResultType];
            } else if ([result isKindOfClass:[PPBlinkOcrRecognizerResult class]]) {
                PPBlinkOcrRecognizerResult *ocrResult = (PPBlinkOcrRecognizerResult *)result;
                for (NSString *parserName in self.parserNames) {
                    [dict setObject:parserName forKey:[ocrResult parsedResultForName:parserName]];
                }
            }

            [dictionaryResults addObject:dict];
        }
    }

    [self.delegate blinkID:self didOutputResults:dictionaryResults];

    // As scanning view controller is presented full screen and modally, dismiss it
    [scanningViewController dismissViewControllerAnimated:YES completion:nil];
}

#pragma mark - BlinkID specifics

/**
 * Method allocates and initializes the Scanning coordinator object.
 * Coordinator is initialized with settings for scanning
 *
 *  @param error Error object, if scanning isn't supported
 *
 *  @return initialized coordinator
 */
- (PPCameraCoordinator *)coordinatorWithError:(NSError **)error {

    /** 0. Check if scanning is supported */

    if ([PPCameraCoordinator isScanningUnsupportedForCameraType:self.cameraType error:error]) {
        return nil;
    }


    /** 1. Initialize the Scanning settings */

    // Initialize the scanner settings object. This initialize settings with all default values.
    PPSettings *settings = [[PPSettings alloc] init];
    settings.cameraSettings.cameraType = self.cameraType;

    // tell which metadata you want to receive. Metadata collection takes CPU time - so use it only if necessary!
    settings.metadataSettings.dewarpedImage = YES; // get dewarped image of ID documents


    /** 2. Setup the license key */

    // Visit www.microblink.com to get the license key for your app
    settings.licenseSettings.licenseKey = self.licenseKey;


    /** 3. Set up what is being scanned. See detailed guides for specific use cases. */

    /**
     * Add all needed recognizers
     */
    for (PPRecognizerSettings *recognizer in self.recognizers) {
        [settings.scanSettings addRecognizerSettings:recognizer];
    }

    /**
     * Add BlinkOCR if parsers exist
     */
    if (self.parsers.count > 0) {
        PPBlinkOcrRecognizerSettings *recognizer = [[PPBlinkOcrRecognizerSettings alloc] init];
        for (PPOcrParserFactory *parser in self.parsers) {
            [recognizer addOcrParser:parser name:[self.parserNames objectAtIndex:[self.parsers indexOfObject:parser]]];
        }
        [settings.scanSettings addRecognizerSettings:recognizer];
    }

    /**
     * Add Detector recognizer
     */
    if (self.detectors.count > 0) {
        PPMultiDetectorSettings *multiDetectorSettings = [[PPMultiDetectorSettings alloc] initWithSettingsArray:self.detectors];
        PPDetectorRecognizerSettings *recognizer = [[PPDetectorRecognizerSettings alloc] initWithDetectorSettings:multiDetectorSettings];
        [settings.scanSettings addRecognizerSettings:recognizer];
    }

    /** 4. Initialize the Scanning Coordinator object */

    PPCameraCoordinator *coordinator = [[PPCameraCoordinator alloc] initWithSettings:settings];

    return coordinator;
}

#pragma mark - Recognizers

- (BOOL)recognizerExists:(PPRecognizerSettings *)recognizer {
    for (PPRecognizerSettings *temp in self.recognizers) {
        if ([temp isKindOfClass:[recognizer class]]) {
            if ([recognizer isKindOfClass:[PPEudlRecognizerSettings class]]) {
                [self.recognizers removeObject:temp];
                [self.recognizers addObject:[[PPEudlRecognizerSettings alloc] initWithEudlCountry:PPEudlCountryAny]];
            }
            return YES;
        }
    }
    return NO;
}

- (BOOL)idExists:(NSString *)id {
    BOOL found = [id isEqualToString:@"Mrtd"] || [id isEqualToString:@"Usdl"] || [id isEqualToString:@"Ukdl"] ||
                 [id isEqualToString:@"Dedl"] || [id isEqualToString:@"Eudl"] || [id isEqualToString:@"MyKad"] ||
                 [id isEqualToString:@"Pdf417"] || [id isEqualToString:@"BarDecoder"] || [id isEqualToString:@"ZXing"];
    if (found) {
        NSLog(@"Parser ID cannot have same ID (%@) as one of recognizers!\nPlease use different ID for a parser!", id);
        return YES;
    }
    for (NSString *temp in self.parserNames) {
        if ([temp isEqualToString:id]) {
            NSLog(@"Parser ID with selected ID (%@) already exists!\nPlease use different ID!", id);
            return YES;
            ;
        }
    }
    return NO;
}

- (void)addAusIDBackRecognizer {
    PPAusIDBackRecognizerSettings *recognizer = [[PPAusIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addAusIDFrontRecognizer {
    PPAusIDFrontRecognizerSettings *recognizer = [[PPAusIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addAusPassportRecognizer {
    PPAusPassportRecognizerSettings *recognizer = [[PPAusPassportRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addAusIDCombinedRecognizer {
//    PPAusIDCombinedRecognizerSettings *recognizer = [[PPAusIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addBarDecoderRecognizer {
    PPBarDecoderRecognizerSettings *recognizer = [[PPBarDecoderRecognizerSettings alloc] init];
    recognizer.scanCode128 = YES;
    recognizer.scanCode39 = YES;
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addBarcodeRecognizer {
    PPBarcodeRecognizerSettings *recognizer = [[PPBarcodeRecognizerSettings alloc] init];
    recognizer.scanQR = YES;
    recognizer.scanITF = YES;
    recognizer.scanEAN8 = YES;
    recognizer.scanUPCA = YES;
    recognizer.scanUPCE = YES;
    recognizer.scanAztec = YES;
    recognizer.scanEAN13 = YES;
    recognizer.scanCode128 = YES;
    recognizer.scanDataMatrix = YES;
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addCroIdBackRecognizer {
    PPCroIDBackRecognizerSettings *recognizer = [[PPCroIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addCroIdFrontRecognizer {
    PPCroIDFrontRecognizerSettings *recognizer = [[PPCroIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addCroCombinedRecognizer {
//    PPCroIDCombinedRecognizerSettings *recognizer = [[PPCroIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addCzIDBackRecognizer {
    PPCzIDBackRecognizerSettings *recognizer = [[PPCzIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addCzIDFrontRecognizer {
    PPCzIDFrontRecognizerSettings *recognizer = [[PPCzIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addCzCombinedRecognizer {
//    PPCzIDCombinedRecognizerSettings *recognizer = [[PPCzIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addEudlRecognizer {
    PPEudlRecognizerSettings *recognizer = [[PPEudlRecognizerSettings alloc] initWithEudlCountry:PPEudlCountryAny];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addGerIDFrontRecognizer {
    PPGermanIDFrontRecognizerSettings *recognizer = [[PPGermanIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addGerIDBackRecognizer {
    PPGermanIDBackRecognizerSettings *recognizer = [[PPGermanIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addGerIDOldRecognizer {
    PPGermanOldIDRecognizerSettings *recognizer = [[PPGermanOldIDRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addGerPassportRecognizer {
    PPGermanPassportRecognizerSettings *recognizer = [[PPGermanPassportRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addGerCombinedRecognizer {
//    PPGermanIDCombinedRecognizerSettings *recognizer = [[PPGermanIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addMrtdRecognizer {
    PPMrtdRecognizerSettings *recognizer = [[PPMrtdRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addMyKadRecognizer {
    PPMyKadFrontRecognizerSettings *recognizer = [[PPMyKadFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addIKadRecognizer {
    PPiKadRecognizerSettings *recognizer = [[PPiKadRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addPdf417Recognizer {
    PPPdf417RecognizerSettings *recognizer = [[PPPdf417RecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addSerbIDBackRecognizer {
    PPSerbianIDBackRecognizerSettings *recognizer = [[PPSerbianIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addSerbIDFrontRecognizer {
    PPSerbianIDFrontRecognizerSettings *recognizer = [[PPSerbianIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addSerbIDCombinedRecognizer {
//    PPSerbianIDCombinedRecognizerSettings *recognizer = [[PPSerbianIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addSlovakIDBackRecognizer {
    PPSlovakIDBackRecognizerSettings *recognizer = [[PPSlovakIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addSlovakIDFrontRecognizer {
    PPSlovakIDFrontRecognizerSettings *recognizer = [[PPSlovakIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addSlovakCombinedRecognizer {
//    PPSlovakIDCombinedRecognizerSettings *recognizer = [[PPSlovakIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addSlovenianIDBackRecognizer {
    PPSlovenianIDBackRecognizerSettings *recognizer = [[PPSlovenianIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addSlovenianIDFrontRecognizer {
    PPSlovenianIDFrontRecognizerSettings *recognizer = [[PPSlovenianIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addSlovenianCombinedRecognizer {
//    PPSlovenianIDCombinedRecognizerSettings *recognizer = [[PPSlovenianIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addSingaporeIDBackRecognizer {
    PPSingaporeIDBackRecognizerSettings *recognizer = [[PPSingaporeIDBackRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addSingaporeIDFrontRecognizer {
    PPSingaporeIDFrontRecognizerSettings *recognizer = [[PPSingaporeIDFrontRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addSingaporeCombinedRecognizer {
//    PPSingaporeIDCombinedRecognizerSettings *recognizer = [[PPSingaporeIDCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

- (void)addSwissPassportRecognizer {
    PPSwissPassportRecognizerSettings *recognizer = [[PPSwissPassportRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addUsdlRecognizer {
    PPUsdlRecognizerSettings *recognizer = [[PPUsdlRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addAusdlRecognizer {
    PPEudlRecognizerSettings *recognizer = [[PPEudlRecognizerSettings alloc] initWithEudlCountry:PPEudlCountryAustria];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addUkdlRecognizer {
    PPEudlRecognizerSettings *recognizer = [[PPEudlRecognizerSettings alloc] initWithEudlCountry:PPEudlCountryUnitedKingdom];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addDedlRecognizer {
    PPEudlRecognizerSettings *recognizer = [[PPEudlRecognizerSettings alloc] initWithEudlCountry:PPEudlCountryGermany];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addZXingRecognizer {
    PPZXingRecognizerSettings *recognizer = [[PPZXingRecognizerSettings alloc] init];
    recognizer.scanQR = YES;
    recognizer.scanITF = YES;
    recognizer.scanEAN8 = YES;
    recognizer.scanUPCA = YES;
    recognizer.scanUPCE = YES;
    recognizer.scanAztec = YES;
    recognizer.scanEAN13 = YES;
    recognizer.scanCode128 = YES;
    recognizer.scanDataMatrix = YES;
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

- (void)addVinRecognizer {
    PPVinRecognizerSettings *recognizer = [[PPVinRecognizerSettings alloc] init];
    if (![self recognizerExists:recognizer]) {
        [self.recognizers addObject:recognizer];
    }
}

//- (void)addMrtdCombinedRecognizer {
//    PPMrtdCombinedRecognizerSettings *recognizer = [[PPMrtdCombinedRecognizerSettings alloc] init];
//    if (![self recognizerExists:recognizer]) {
//        [self.recognizers addObject:recognizer];
//    }
//}

#pragma mark - Parsers

- (void)addRawParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPOcrParserFactory *factory = [[PPRawOcrParserFactory alloc] init];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addAmountParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPOcrParserFactory *factory = [[PPPriceOcrParserFactory alloc] init];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addDateParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPOcrParserFactory *factory = [[PPDateOcrParserFactory alloc] init];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addEmailParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPOcrParserFactory *factory = [[PPEmailOcrParserFactory alloc] init];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addIbanParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPOcrParserFactory *factory = [[PPIbanOcrParserFactory alloc] init];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addVinParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPOcrParserFactory *factory = [[PPVinOcrParserFactory alloc] init];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addLicensePlatesParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPLicensePlatesParserFactory *factory = [[PPLicensePlatesParserFactory alloc] init];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addTopUpOcrParser:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPTopUpOcrParserFactory *factory = [[PPTopUpOcrParserFactory alloc] initWithTopUpPrefix:PPTopUpPrefixGeneric];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

- (void)addRegexParser:(NSString *)regex identifier:(NSString *)identifier {
    if ([self idExists:identifier]) {
        return;
    }
    PPOcrParserFactory *factory = [[PPRegexOcrParserFactory alloc] initWithRegex:regex];
    factory.isRequired = NO;
    [self.parsers addObject:factory];
    [self.parserNames addObject:identifier];
}

#pragma mark - Detectors

- (BOOL)detectorExists:(PPDetectorSettings *)settings {
    for (PPDetectorSettings *sett in self.detectors) {
        if ([sett isKindOfClass:[settings class]]) {
            return YES;
        }
    }
    return NO;
}

- (void)addIdCardDetector {

    PPDocumentDetectorSettings *detectorSettings = [[PPDocumentDetectorSettings alloc] initWithNumStableDetectionsThreshold:3];
    PPDocumentSpecification *specification = [PPDocumentSpecification newFromPreset:PPDocumentPresetId1Card];
    [detectorSettings setDocumentSpecifications:@[ specification ]];

    if ([self detectorExists:detectorSettings]) {
        return;
    }

    [self.detectors addObject:detectorSettings];
}

#pragma mark - Clearing

- (void)clearAllRecognizers {
    [self.recognizers removeAllObjects];
}

- (void)clearAllParsers {
    [self.parsers removeAllObjects];
    [self.parserNames removeAllObjects];
}

- (void)clearAllDetectors {
    [self.detectors removeAllObjects];
}

#pragma mark - Utils
- (void)setDictionary:(NSMutableDictionary *)dict withMrtdRecognizerResult:(PPMrtdRecognizerResult *)mrtdResult {
    [dict setObject:[mrtdResult rawDateOfBirth] forKey:kMRTDDateOfBirth];
    [dict setObject:[mrtdResult rawDateOfExpiry] forKey:kMRTDDateOExpiry];
    [dict setObject:@"Mrtd" forKey:kResultType];
}


@end
