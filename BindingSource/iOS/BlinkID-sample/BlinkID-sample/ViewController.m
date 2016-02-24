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

    [BlinkID instance].licenseKey = @"YMHPI7FD-F7QS7YSN-Z3YVTA6N-GI4VI4MI-B5T5RBUN-IG3P7PLY-CGAIJ7IA-LPLN67WS";
    [BlinkID instance].delegate = self;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)didTapScan:(id)sender {
    [[BlinkID instance] scan];
}

#pragma mark - BlinkIDDelegate

- (void)blinkID:(BlinkID *)blinkid didOutputResults:(NSArray<NSDictionary *> *)results {

    for (NSDictionary *result in results) {
        NSLog(@"Result %@", result);
    }
}


@end
