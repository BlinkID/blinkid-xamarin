//
//  BlinkID.h
//  BlinkID
//
//  Created by Jura on 24/02/16.
//  Copyright © 2016 MicroBlink. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol BlinkIDDelegate;

@interface BlinkID : NSObject

@property (nonatomic, weak) id<BlinkIDDelegate> delegate;

@property (nonatomic) NSString *licenseKey;

+ (instancetype)instance;

// Recognizers

- (void)addAusIDBackRecognizerSettings;

- (void)addAusIDFrontRecognizerSettings;

- (void)addBarDecoderRecognizer;

- (void)addCroIdBackRecognizer;

- (void)addCroIdFrontRecognizer;

- (void)addCzIDBackRecognizer;

- (void)addCzIDFrontRecognizer;

- (void)addEudlRecognizer;

- (void)addMrtdRecognizer;

- (void)addMyKadRecognizer;

- (void)addPdf417Recognizer;

- (void)addSingaporeIDRecognizerSettings;

- (void)addUsdlRecognizer;

- (void)addUkdlRecognizer;

- (void)addDedlRecognizer;

- (void)addZXingRecognizer;

// Parsers

- (void)addRawParser:(NSString *)id;

- (void)addAmountParser:(NSString *)id;

- (void)addDateParser:(NSString *)id;

- (void)addEmailParser:(NSString *)id;

- (void)addIbanParser:(NSString *)id;

- (void)addVinParser:(NSString *)id;

- (void)addRegexParser:(NSString *)regex id:(NSString *)id;

// Detectors
- (void)addIdCardDetector;

- (void)clearAllRecognizers;

- (void)clearAllParsers;

- (void)clearAllDetectors;

// Scan

- (void)scan:(BOOL)isFrontCamera;

@end


@protocol BlinkIDDelegate <NSObject>

- (void)blinkID:(BlinkID *)blinkid
didOutputResults:(NSArray<NSDictionary *> *)results;

- (void)blinkID:(BlinkID *)blinkid
 didOutputImage:(UIImage *)image
           name:(NSString *)name;

@end

// In this header, you should import all the public headers of your framework using statements like #import <BlinkID/PublicHeader.h>


