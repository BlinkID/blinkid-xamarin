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

@property (nonatomic, strong) NSString* licenseKey;

+ (instancetype)instance;

- (void)scan;

@end


@protocol BlinkIDDelegate <NSObject>

- (void)blinkID:(BlinkID *)blinkid
didOutputResults:(NSArray<NSDictionary *> *)results;

@end

// In this header, you should import all the public headers of your framework using statements like #import <BlinkID/PublicHeader.h>


