//
//  BlinkID.h
//  BlinkID
//
//  Created by Jura on 24/02/16.
//  Copyright © 2016 MicroBlink. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef NS_ENUM(NSInteger, RecognizerType) {
    /** Pdf417 recognizer */
    RecognizerTypePDF417,
    /** US Driver's License recognizer */
    RecognizerTypeUSDL,
    /** Bardecoder recognizer */
    RecognizerTypeBARDECODER,
    /** Zxing recognizer */
    RecognizerTypeZXING,
    /** Machine Readable Travel Document recognizer */
    RecognizerTypeMRTD,
    /** German Driver's License recognizer */
    RecognizerTypeDEDL,
    /** UK Driver's License recognizer */
    RecognizerTypeUKDL,
    /** EU Driver's License recognizer, scans all supported EU Driver's Licenses */
    RecognizerTypeEUDL,
    /** Malaysian MyKad ID document recognizer */
    RecognizerTypeMYKAD,
    /** Croatian ID card front side recognizer */
    RecognizerTypeCRO_ID_FRONT,
    /** Croatian ID card back side recognizer */
    RecognizerTypeCRO_ID_BACK,
    /** Singapore ID card recognizer */
    RecognizerTypeSINGAPORE_ID
};

typedef NS_ENUM(NSUInteger, CameraType) {
    
    CameraTypeFront,
    CameraTypeBack,
};

@protocol BlinkIDDelegate;

@interface BlinkID : NSObject

@property (nonatomic, weak) id<BlinkIDDelegate> delegate;

@property (nonatomic) NSString *licenseKey;

+ (instancetype)instance;

- (void)scan:(NSArray<NSNumber*> *)recognizers cameraType:(CameraType)cameraType;

@end


@protocol BlinkIDDelegate <NSObject>

- (void)blinkID:(BlinkID *)blinkid
didOutputResults:(NSArray<NSDictionary *> *)results;

@end

// In this header, you should import all the public headers of your framework using statements like #import <BlinkID/PublicHeader.h>


