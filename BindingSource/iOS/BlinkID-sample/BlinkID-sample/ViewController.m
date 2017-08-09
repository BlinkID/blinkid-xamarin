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

    // Valid until 2017-11-07
    [BlinkID instance].licenseKey = @"7QA5M6VI-A6XYOHC2-WVEH4KCH-F7RE3TXQ-SMQ2SAVT-SYEE4GHL-JAAFW5XW-3XN67FPM";
    [BlinkID instance].delegate = self;
    [[BlinkID instance] addMrtdRecognizer];
    [[BlinkID instance] addSwissPassportRecognizer];
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
