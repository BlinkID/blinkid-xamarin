//
//  ViewController.m
//  BlinkID-sample
//
//  Created by Jura on 24/02/16.
//  Copyright © 2016 MicroBlink. All rights reserved.
//

#import "ViewController.h"

#import <BlinkID/BlinkID.h>

@interface ViewController () <BlinkIDDelegate>

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    [BlinkID instance].licenseKey = @"6YYN5NIG-O32K2V7G-5KPDEQNW-766XQEMA-QT6QAW6W-VAD2ZSX7-XV4BDAEF-FD2M3PXF";
    [BlinkID instance].delegate = self;
    [[BlinkID instance] addIdCardDetector];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)didTapScan:(id)sender {
    [[BlinkID instance] scan:NO];
}

#pragma mark - BlinkIDDelegate

- (void)blinkID:(BlinkID *)blinkid didOutputResults:(NSArray<NSDictionary *> *)results {

    for (NSDictionary *result in results) {
        NSLog(@"Result %@", result);
    }
}

- (void)blinkID:(BlinkID *)blinkid didOutputImage:(UIImage *)image name:(NSString *)name {
    NSLog(@"Received image with name %@, size (%d, %d)", name, (int) image.size.width, (int) image.size.height);
}


@end
