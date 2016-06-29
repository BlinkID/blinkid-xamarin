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

@property (nonatomic) NSArray<NSNumber*> *recognizers;

@end

@implementation BlinkID

+ (instancetype)instance {
    static BlinkID *sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[BlinkID alloc] init];
    });
    
    NSLog(@"Returning shared instance");
    
    return sharedInstance;
}

- (void)scan:(NSArray<NSNumber*> *)recognizers cameraType:(CameraType)cameraType {
    
    self.recognizers = recognizers;
    if (cameraType == PPCameraTypeBack) {
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
    UIViewController<PPScanningViewController>* scanningViewController = [PPViewControllerFactory cameraViewControllerWithDelegate:self coordinator:coordinator error:nil];

    // allow rotation if VC is displayed as a modal view controller
    scanningViewController.autorotate = YES;
    scanningViewController.supportedOrientations = UIInterfaceOrientationMaskAll;
    
    UIViewController *rootViewController = [[[UIApplication sharedApplication] keyWindow] rootViewController];
    [rootViewController presentViewController:scanningViewController animated:YES completion:nil];

    NSLog(@"Presenting View Controller %p %@", rootViewController, rootViewController);
    
}

#pragma mark - PPScanDelegate

- (void)scanningViewControllerUnauthorizedCamera:(UIViewController<PPScanningViewController> *)scanningViewController {
    // Add any logic which handles UI when app user doesn't allow usage of the phone's camera
}

- (void)scanningViewController:(UIViewController<PPScanningViewController> *)scanningViewController
                  didFindError:(NSError *)error {
    // Can be ignored. See description of the method
}

- (void)scanningViewControllerDidClose:(UIViewController<PPScanningViewController> *)scanningViewController {

    // As scanning view controller is presented full screen and modally, dismiss it
    [scanningViewController dismissViewControllerAnimated:YES completion:nil];
}

- (void)scanningViewController:(UIViewController<PPScanningViewController> *)scanningViewController
              didOutputResults:(NSArray *)results {

    // Here you process scanning results. Scanning results are given in the array of PPRecognizerResult objects.

    // first, pause scanning until we process all the results
    [scanningViewController pauseScanning];

    NSMutableArray<NSDictionary *> *dictionaryResults = [[NSMutableArray alloc] init];

    const NSString *resultTypeKey = @"ResultType";

    for (id obj in results) {
        if ([obj isKindOfClass:[PPRecognizerResult class]]) {
            PPRecognizerResult *result = (PPRecognizerResult *)obj;

            NSMutableDictionary *dict = [[result getAllStringElements] mutableCopy];

            if ([result isKindOfClass:[PPMrtdRecognizerResult class]]) {
                [dict setObject:@"MRTD" forKey:resultTypeKey];
            } else if ([result isKindOfClass:[PPMyKadRecognizerResult class]]) {
                [dict setObject:@"MyKad" forKey:resultTypeKey];
            } else if ([result isKindOfClass:[PPUsdlRecognizerResult class]]) {
                [dict setObject:@"USDL" forKey:resultTypeKey];
            }

            [dictionaryResults addObject:dict];
        }
    }

    [self.delegate blinkID:self didOutputResults:dictionaryResults];

    // As scanning view controller is presented full screen and modally, dismiss it
    [scanningViewController dismissViewControllerAnimated:YES completion:nil];
}

#pragma mark - recognizers

- (void)addMrtdRecognizer:(PPSettings *)settings {
    PPMrtdRecognizerSettings *mrtdRecognizerSettings = [[PPMrtdRecognizerSettings alloc] init];
    [settings.scanSettings addRecognizerSettings:mrtdRecognizerSettings];
}

- (void)addUsdlRecognizer:(PPSettings *)settings {
    PPUsdlRecognizerSettings *usdlRecognizerSettings = [[PPUsdlRecognizerSettings alloc] init];
    [settings.scanSettings addRecognizerSettings:usdlRecognizerSettings];
}

- (void)addMyKadRecognizer:(PPSettings *)settings {
    PPMyKadRecognizerSettings *myKadRecognizerSettings = [[PPMyKadRecognizerSettings alloc] init];
    [settings.scanSettings addRecognizerSettings:myKadRecognizerSettings];
}

- (void)addEudlRecognizer:(PPSettings *)settings {
    PPEudlRecognizerSettings *eudlRecognizerSettings = [[PPEudlRecognizerSettings alloc] init];
    [settings.scanSettings addRecognizerSettings:eudlRecognizerSettings];
}

- (void)addUkdlRecognizer:(PPSettings *)settings {
    PPEudlRecognizerSettings *eudlRecognizerSettings = [[PPEudlRecognizerSettings alloc] initWithEudlCountry:PPEudlCountryUnitedKingdom];
    [settings.scanSettings addRecognizerSettings:eudlRecognizerSettings];
}

- (void)addDedlRecognizer:(PPSettings *)settings {
    PPEudlRecognizerSettings *eudlRecognizerSettings = [[PPEudlRecognizerSettings alloc] initWithEudlCountry:PPEudlCountryGermany];
    [settings.scanSettings addRecognizerSettings:eudlRecognizerSettings];
}

- (void)addPdf417Recognizer:(PPSettings *)settings {
    PPPdf417RecognizerSettings *recognizerSettings = [[PPPdf417RecognizerSettings alloc] init];
    [settings.scanSettings addRecognizerSettings:recognizerSettings];
}

- (void)addBardecoderRecognizer:(PPSettings *)settings {
    PPBarDecoderRecognizerSettings *recognizerSettings = [[PPBarDecoderRecognizerSettings alloc] init];
    [settings.scanSettings addRecognizerSettings:recognizerSettings];
}

- (void)addZxingRecognizer:(PPSettings *)settings {
    PPZXingRecognizerSettings *recognizerSettings = [[PPZXingRecognizerSettings alloc] init];
    [settings.scanSettings addRecognizerSettings:recognizerSettings];
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
- (PPCameraCoordinator *)coordinatorWithError:(NSError**)error {

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

    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypeMRTD]]) {
        [self addMrtdRecognizer:settings];
    }
    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypeUSDL]]) {
        [self addUsdlRecognizer:settings];
    }
    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypeMYKAD]]) {
        [self addMyKadRecognizer:settings];
    }
    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypePDF417]]) {
        [self addPdf417Recognizer:settings];
    }
    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypeBARDECODER]]) {
        [self addBardecoderRecognizer:settings];
    }
    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypeZXING]]) {
        [self addZxingRecognizer:settings];
    }
    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypeUKDL]]) {
        [self addUkdlRecognizer:settings];
    }
    if ([self.recognizers containsObject:[NSNumber numberWithInteger:RecognizerTypeDEDL]]) {
        [self addDedlRecognizer:settings];
    }

    /** 4. Initialize the Scanning Coordinator object */
    
    PPCameraCoordinator *coordinator = [[PPCameraCoordinator alloc] initWithSettings:settings];
    
    NSLog(@"Returning coordinator");
    
    return coordinator;
}


@end
