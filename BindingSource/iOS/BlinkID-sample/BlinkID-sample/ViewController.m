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

    [BlinkID instance].licenseKey = @"JHUETMI2-Z5F4T3F5-PAGHBQ3P-TCM5FVCF-2CSYYOKU-OGEA6Z6Y-Q2GUCFXF-Q5QLOYOQ";
    [BlinkID instance].delegate = self;
//    [[BlinkID instance] addIdCardDetector];
    [[BlinkID instance] addGerMrzRecognizer];
    
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
