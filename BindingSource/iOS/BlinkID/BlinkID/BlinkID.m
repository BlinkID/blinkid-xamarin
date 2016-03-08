//
//  BlinkID.m
//  MicroBlink
//
//  Created by Jura on 24/02/16.
//  Copyright © 2016 MicroBlink. All rights reserved.
//

#import "BlinkID.h"

#import <MicroBlink/MicroBlink.h>

@interface BlinkID () <PPScanDelegate>

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

- (void)scan {

    /** Instantiate the scanning coordinator */
    NSError *error;
    PPCoordinator *coordinator = [self coordinatorWithError:&error];

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
    UIViewController<PPScanningViewController>* scanningViewController = [coordinator cameraViewControllerWithDelegate:self];

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
            } else if ([result isKindOfClass:[PPUkdlRecognizerResult class]]) {
                [dict setObject:@"UKDL" forKey:resultTypeKey];
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
- (PPCoordinator *)coordinatorWithError:(NSError**)error {

    /** 0. Check if scanning is supported */

    if ([PPCoordinator isScanningUnsupportedForCameraType:PPCameraTypeBack error:error]) {
        return nil;
    }


    /** 1. Initialize the Scanning settings */

    // Initialize the scanner settings object. This initialize settings with all default values.
    PPSettings *settings = [[PPSettings alloc] init];

    // tell which metadata you want to receive. Metadata collection takes CPU time - so use it only if necessary!
    settings.metadataSettings.dewarpedImage = YES; // get dewarped image of ID documents


    /** 2. Setup the license key */

    // Visit www.microblink.com to get the license key for your app
    settings.licenseSettings.licenseKey = self.licenseKey;


    /** 3. Set up what is being scanned. See detailed guides for specific use cases. */

    { // Remove this if you're not using MRTD recognition

        // To specify we want to perform MRTD (machine readable travel document) recognition, initialize the MRTD recognizer settings
        PPMrtdRecognizerSettings *mrtdRecognizerSettings = [[PPMrtdRecognizerSettings alloc] init];

        // tell the library to get full image of the document. Setting this to YES makes sense just if
        // settings.metadataSettings.dewarpedImage = YES, otherwise it wastes CPU time.
        mrtdRecognizerSettings.dewarpFullDocument = NO;

        // Add MRTD Recognizer setting to a list of used recognizer settings
        [settings.scanSettings addRecognizerSettings:mrtdRecognizerSettings];
    }

    { // Remove this if you're not using USDL recognition

        // To specify we want to perform USDL (US Driver's license) recognition, initialize the USDL recognizer settings
        PPUsdlRecognizerSettings *usdlRecognizerSettings = [[PPUsdlRecognizerSettings alloc] init];

        // Add USDL Recognizer setting to a list of used recognizer settings
        [settings.scanSettings addRecognizerSettings:usdlRecognizerSettings];
    }

    { // Remove this if you're not using UKDL recognition

        // To specify we want to perform UKDL (UK Driver's license) recognition, initialize the UKDL recognizer settings
        PPUkdlRecognizerSettings *ukdlRecognizerSettings = [[PPUkdlRecognizerSettings alloc] init];

        // If you want to save the image of the UKDL, set this to YES
        ukdlRecognizerSettings.showFullDocument = YES;

        // Add UKDL Recognizer setting to a list of used recognizer settings
        [settings.scanSettings addRecognizerSettings:ukdlRecognizerSettings];
    }

    /** 4. Initialize the Scanning Coordinator object */
    
    PPCoordinator *coordinator = [[PPCoordinator alloc] initWithSettings:settings];
    
    NSLog(@"Returning coordinator");
    
    return coordinator;
}


@end
